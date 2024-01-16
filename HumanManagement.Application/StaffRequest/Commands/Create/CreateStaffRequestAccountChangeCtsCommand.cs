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
    public class CreateStaffRequestAccountChangeCtsCommand : IRequest<Result>
    {
        public StaffRequestAccountChangeDto StaffRequestAccountChange { get; set; }
    }
    public class CreateStaffRequestAccountChangeCtsCommandHandler : IRequestHandler<CreateStaffRequestAccountChangeCtsCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestAccountChangeCts> baseStaffRequestAccountChangeCtsRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IHubContext<Notifications> _hubContext;

        public CreateStaffRequestAccountChangeCtsCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                                IBaseRepository<StaffRequestAccountChangeCts> baseStaffRequestAccountChangeCtsRepository,
                                                                IBaseRepository<NotificationModel> baseNotificationRepository,
                                                                ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                                IStaffRequestRepository staffRequestRepository,
                                                                IMapper mapper,
                                                                IOptions<AppSettings> appSettings,
                                                                IHubContext<Notifications> hubContext)
        {
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseStaffRequestAccountChangeCtsRepository = baseStaffRequestAccountChangeCtsRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
            _hubContext = hubContext;
        } 
        public async Task<Result> Handle(CreateStaffRequestAccountChangeCtsCommand request, CancellationToken cancellationToken)
        {
            request.StaffRequestAccountChange.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
            var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestAccountChange.StaffRequest);
            staffRequest.SetStatePending();
            await baseStaffRequestRepository.Add(staffRequest);
            var staffRequestAccountChange = mapper.Map<StaffRequestAccountChangeCts>(request.StaffRequestAccountChange);
            staffRequestAccountChange.SetIdStaffRequest(staffRequest.Id);
            staffRequestAccountChange.AccountNumberCts = string.Empty;
            await baseStaffRequestAccountChangeCtsRepository.Add(staffRequestAccountChange);
            var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
            await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
            if (approver != null) 
            {
                var employee = request.StaffRequestAccountChange.StaffRequest.StaffRequestEmployee;
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
                var notificationCreator = new NotificationCreator(request.StaffRequestAccountChange.GetIdPerson(),
                                                                  appSettings.StaffRequestNotificationTemplateHtml,
                                                                  appSettings.UrlStaffRequest,
                                                                  request.StaffRequestAccountChange.StaffRequest.TypeStaffRequest,
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
