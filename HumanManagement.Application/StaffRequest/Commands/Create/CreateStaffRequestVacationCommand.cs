using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System.Threading;
using HumanManagement.Domain.StaffRequest.Models;
using System.Threading.Tasks;
using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using System;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.StaffRequest.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.SignalR;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CreateStaffRequestVacationCommand : IRequest<Result>
    {
        public StaffRequestVacationDto StaffRequestVacation { get; set; }
    }
    public class CreateStaffRequestCommandHandler : IRequestHandler<CreateStaffRequestVacationCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestVacation> baseStaffRequestVacationRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly AppSettings appSettings;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitWork;
        private readonly IHubContext<Notifications> _hubContext;

        public CreateStaffRequestCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                IBaseRepository<StaffRequestVacation> baseStaffRequestVacationRepository,
                                                IBaseRepository<NotificationModel> baseNotificationRepository,
                                                ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                IStaffRequestRepository staffRequestRepository,
                                                IOptions<AppSettings> appSettings,
                                                IMapper mapper,
                                                IUnitOfWork unitWork,
                                                IHubContext<Notifications> hubContext)
        {
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseStaffRequestVacationRepository = baseStaffRequestVacationRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
            this.unitWork = unitWork;
            _hubContext = hubContext;
        }
        public async Task<Result> Handle(CreateStaffRequestVacationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.StaffRequestVacation.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
                var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestVacation.StaffRequest);
                staffRequest.SetStatePending();


                var list = await staffRequestRepository.GetDatesByEmployee(staffRequest.IdEmployee);

                bool permitido = true;
                foreach (var item in list)
                {
                    bool ms = (DateTime.Compare(item.end_time, request.StaffRequestVacation.StartVacation) < 0);

                    if (!ms)
                    {
                        ms = (DateTime.Compare(request.StaffRequestVacation.EndVacation, item.start_time) < 0);
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

                
                request.StaffRequestVacation.NumberOutstandingBalance = 5;
                request.StaffRequestVacation.NumberTruncatedBalance = 10;
                var staffRequestVacation = mapper.Map<StaffRequestVacation>(request.StaffRequestVacation);
                staffRequestVacation.SetIdStaffRequest(staffRequest.Id);

                await baseStaffRequestVacationRepository.Add(staffRequestVacation);
                var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
                await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
                if (approver != null)
                {
                    var employee = request.StaffRequestVacation.StaffRequest.StaffRequestEmployee;
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
                    var notificationCreator = new NotificationCreator(request.StaffRequestVacation.GetIdPerson(),
                                                                      appSettings.StaffRequestNotificationTemplateHtml,
                                                                      appSettings.UrlStaffRequest,
                                                                      request.StaffRequestVacation.StaffRequest.TypeStaffRequest,
                                                                      receptorList,
                                                                      _hubContext);
                    await notificationCreator.GenerateNotification(1);
                    var notificationList = notificationCreator.Notificationlist;
                    await baseNotificationRepository.AddRange(notificationList);
                }
                await unitWork.Commit();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
            catch (Exception ex)
            {
                await unitWork.Rollback();
                throw ex;
            }
        }
    }
}
