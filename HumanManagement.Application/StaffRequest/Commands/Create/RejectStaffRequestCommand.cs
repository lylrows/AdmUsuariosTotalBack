using AutoMapper;
using HumanManagement.Application.Helpers;
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
using static HumanManagement.CrossCutting.Utils.Constants;
using StaffRequestApprover = HumanManagement.Domain.StaffRequest.Models.StaffRequestApprover;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class RejectStaffRequestCommand : IRequest<Result>
    {
        public StaffRequestApproverDto StaffRequestApprover { get; set; }
    }
    public class RejectStaffRequestCommandHandler : IRequestHandler<RejectStaffRequestCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestApprover> baseRepository;
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly SessionManager sessionManager;
        private readonly IHubContext<Notifications> _hubContext;
        public RejectStaffRequestCommandHandler(IBaseRepository<StaffRequestApprover> baseRepository,
                                                        IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<NotificationModel> baseNotificationRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                        IMapper mapper,
                                                        IOptions<AppSettings> appSettings,
                                                        SessionManager sessionManager,
                                                        IHubContext<Notifications> hubContext)
        {
            this.baseRepository = baseRepository;
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.appSettings = appSettings.Value;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
            this.mapper = mapper;
            this.sessionManager = sessionManager;
            _hubContext = hubContext;
        }
        public async Task<Result> Handle(RejectStaffRequestCommand request, CancellationToken cancellationToken)
        {
            var staffRequestApprover = mapper.Map<StaffRequestApprover>(request.StaffRequestApprover);
            staffRequestApprover.IdEmployee = sessionManager.User.IdEmployee;
            var employee = await staffRequestRepository.GetEmployeeById(sessionManager.User.IdEmployee);
            staffRequestApprover.IdCharge = employee.IdCharge;
            var staffRequest = new StaffRequestModel
            {
                Id = staffRequestApprover.IdStaffRequest
            };
            staffRequest.SetStateRejected();
            staffRequest.SetComment(staffRequestApprover.Comment);
            staffRequestApprover.SetState(staffRequest.State);
            await baseRepository.Add(staffRequestApprover);
            await baseStaffRequestRepository.UpdatePartial(staffRequest, x => x.State, x => x.Comment);
            var typeStaffRequest = await baseTypeStaffRequestRepository.Find(request.StaffRequestApprover.IdTypeStaffRequest);
            var requestEmployee = await staffRequestRepository.GetById(request.StaffRequestApprover.IdStaffRequest);
            var employeeColaborator = requestEmployee.StaffRequestEmployee;
            var receptorList = new List<NotificationReceptorDto>();
            receptorList.Add(new NotificationReceptorDto
            {
                IdArea = employeeColaborator.IdArea,
                IdReceptor = employeeColaborator.IdPerson,
                TypeStaffRequest = typeStaffRequest.Name,
                EmplyeeFullName = $"{employeeColaborator.Names} {employeeColaborator.LastName} {employeeColaborator.MotherLastName}",
                EmplyeeDni = employeeColaborator.Dni,
                RolName = employeeColaborator.Charge,
                IdStaffRequest = staffRequest.Id
            });
            var notification = new NotificationCreator(employee.IdPerson,
                                                        appSettings.StaffRequestNotificationRejectTemplateHtml,
                                                        appSettings.UrlStaffRequest,
                                                        typeStaffRequest.Name,
                                                        receptorList,
                                                        _hubContext);
            await notification.GenerateNotification(2);
            var notificationList = notification.Notificationlist;
            await baseNotificationRepository.AddRange(notificationList);


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
