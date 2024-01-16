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
    public class CreateStaffRequestJustificationtardinessCommand : IRequest<Result>
    {
        public StaffRequestJustificationTardinessDto StaffRequestJustificationTardiness { get; set; }
    }
    public class CreateStaffRequestJustificationtardinessCommandHandler : IRequestHandler<CreateStaffRequestJustificationtardinessCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestJustificationTardiness> baseStaffRequestJustificationTardinessRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IHubContext<Notifications> _hubContext;

        public CreateStaffRequestJustificationtardinessCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                                    IBaseRepository<StaffRequestJustificationTardiness> baseStaffRequestJustificationTardinessRepository,
                                                                    IBaseRepository<NotificationModel> baseNotificationRepository,
                                                                    ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                                    IStaffRequestRepository staffRequestRepository,
                                                                    IMapper mapper,
                                                                    IOptions<AppSettings> appSettings,
                                                                    IHubContext<Notifications> hubContext)
        {
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseStaffRequestJustificationTardinessRepository = baseStaffRequestJustificationTardinessRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
            _hubContext = hubContext;
        }
        public async Task<Result> Handle(CreateStaffRequestJustificationtardinessCommand request, CancellationToken cancellationToken)
        {
            request.StaffRequestJustificationTardiness.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
            var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestJustificationTardiness.StaffRequest);
            staffRequest.SetStatePending();
            await baseStaffRequestRepository.Add(staffRequest);
            var staffRequestJustificacionTardiness = mapper.Map<StaffRequestJustificationTardiness>(request.StaffRequestJustificationTardiness);
            staffRequestJustificacionTardiness.tardinessDate = request.StaffRequestJustificationTardiness.DateAbsence;
            staffRequestJustificacionTardiness.SetIdStaffRequest(staffRequest.Id);
            await baseStaffRequestJustificationTardinessRepository.Add(staffRequestJustificacionTardiness);
            var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
            await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
            if (approver != null)
            {
                var employee = request.StaffRequestJustificationTardiness.StaffRequest.StaffRequestEmployee;
                //int idArea = approver.AllowApproveAll ? 0 : employee.IdArea;
                int idArea = employee.IdArea;
                var receptorList = await staffRequestRepository.GetListReceptorForNotification(approver.IdProfile, idArea);
                receptorList.ForEach(x =>
                {
                    x.EmplyeeFullName = $"{employee.Names} {employee.LastName} {employee.MotherLastName}";
                    x.EmplyeeDni = employee.Dni;
                    x.RolName = employee.Charge;
                    x.IdStaffRequest = staffRequest.Id;
                });
                var notificationCreator = new NotificationCreator(request.StaffRequestJustificationTardiness.GetIdPerson(),
                                                                  appSettings.StaffRequestNotificationTemplateHtml,
                                                                  appSettings.UrlStaffRequest,
                                                                  request.StaffRequestJustificationTardiness.StaffRequest.TypeStaffRequest,
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
