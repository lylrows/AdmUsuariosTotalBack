using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CreateStaffRequestAbsenceCommand : IRequest<Result>
    {
        public StaffRequestAbsenceDto StaffRequestAbsence { get; set; }
    }
    public class CreateStaffRequestAbsenceCommandHandler : IRequestHandler<CreateStaffRequestAbsenceCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestAbsence> baseStaffRequestAbsenceRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IHubContext<Notifications> _hubContext;

        public CreateStaffRequestAbsenceCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                        IBaseRepository<StaffRequestAbsence> baseStaffRequestAbsenceRepository,
                                                        IBaseRepository<NotificationModel> baseNotificationRepository,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        IMapper mapper,
                                                        IOptions<AppSettings> appSettings,
                                                        IHubContext<Notifications> hubContext)
        {
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseStaffRequestAbsenceRepository = baseStaffRequestAbsenceRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
            _hubContext = hubContext;
        }
        public async Task<Result> Handle(CreateStaffRequestAbsenceCommand request, CancellationToken cancellationToken)
        {
            request.StaffRequestAbsence.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
            var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestAbsence.StaffRequest);
            staffRequest.SetStatePending();
            await baseStaffRequestRepository.Add(staffRequest);
            var staffRequestAbsence = mapper.Map<StaffRequestAbsence>(request.StaffRequestAbsence);
            staffRequestAbsence.SetIdStaffRequest(staffRequest.Id);
            await baseStaffRequestAbsenceRepository.Add(staffRequestAbsence);
            var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
            await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
            if (approver != null)
            {
                var employee = request.StaffRequestAbsence.StaffRequest.StaffRequestEmployee;
                //int idArea = approver.AllowApproveAll ? 0 : employee.IdArea;
                int idArea = employee.IdArea;
                var receptorList = await staffRequestRepository.GetListReceptorForNotificationBoss(approver.IdProfile, idArea, staffRequest.IdEmployee);
                receptorList.ForEach(x =>
                {
                    x.EmplyeeFullName = $"{employee.Names} {employee.LastName} {employee.MotherLastName}";
                    x.EmplyeeDni = employee.Dni;
                    x.RolName = employee.Charge;
                    x.IdStaffRequest = staffRequest.Id;
                });
                var notificationCreator = new NotificationCreator(request.StaffRequestAbsence.GetIdPerson(),
                                                                  appSettings.StaffRequestNotificationTemplateHtml,
                                                                  appSettings.UrlStaffRequest,
                                                                  request.StaffRequestAbsence.StaffRequest.TypeStaffRequest,
                                                                  receptorList,
                                                                  _hubContext);
                await notificationCreator.GenerateNotification(1);
                var notificationList = notificationCreator.Notificationlist;
                await baseNotificationRepository.AddRange(notificationList);
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
