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
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CreateStaffRequestPermitCommand : IRequest<Result>
    {
        public StaffRequestPermitDto StaffRequestPermit { get; set; }
    }
    public class CreateStaffRequestPermitCommandHandler : IRequestHandler<CreateStaffRequestPermitCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestPermit> baseStaffRequestPermitRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IHubContext<Notifications> _hubContext;

        public CreateStaffRequestPermitCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                      IBaseRepository<StaffRequestPermit> baseStaffRequestPermitRepository,
                                                      IBaseRepository<NotificationModel> baseNotificationRepository,
                                                      ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                      IStaffRequestRepository staffRequestRepository,
                                                      IMapper mapper,
                                                      IOptions<AppSettings> appSettings,
                                                      IHubContext<Notifications> hubContext)
        {
            this.baseStaffRequestPermitRepository = baseStaffRequestPermitRepository;
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
            _hubContext = hubContext;
        }
        public async Task<Result> Handle(CreateStaffRequestPermitCommand request, CancellationToken cancellationToken)
        {
            request.StaffRequestPermit.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();

            var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestPermit.StaffRequest);
            staffRequest.SetStatePending();


            var list = await staffRequestRepository.GetDatesByEmployee(staffRequest.IdEmployee);

            bool permitido = true;
            foreach (var item in list)
            {
                bool ms = (DateTime.Compare(item.end_time, request.StaffRequestPermit.StartTime) < 0);

                if (!ms)
                {
                    ms = (DateTime.Compare(request.StaffRequestPermit.EndTime, item.start_time) < 0);
                    if (!ms)
                        permitido = false;
                }

                if (!permitido)
                    break;
            }

            if (!permitido)
                return new Result
                {
                    StateCode = Constants.StateCodeResult.VALIDATION
                };


            await baseStaffRequestRepository.Add(staffRequest);

            
            request.StaffRequestPermit.NumberOutstandingBalance = 5;
            request.StaffRequestPermit.NumberTruncatedBalance = 10;
            var staffRequestPermit = mapper.Map<StaffRequestPermit>(request.StaffRequestPermit);
            staffRequestPermit.SetIdStaffRequest(staffRequest.Id);

            await baseStaffRequestPermitRepository.Add(staffRequestPermit);
            var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
            await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
            if (approver != null)
            {
                var employee =  request.StaffRequestPermit.StaffRequest.StaffRequestEmployee;
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
                var notificationCreator = new NotificationCreator(request.StaffRequestPermit.GetIdPerson(),
                                                                  appSettings.StaffRequestNotificationTemplateHtml,
                                                                  appSettings.UrlStaffRequest,
                                                                  request.StaffRequestPermit.StaffRequest.TypeStaffRequest,
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
