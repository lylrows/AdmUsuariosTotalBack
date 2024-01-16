using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CreateStaffRequestLoanCommand : IRequest<Result>
    {
        public StaffRequestLoanDto StaffRequestLoan { get; set; }
        public IFormFile file { get; set; }
    } 
    public class CreateStaffRequestLoanCommandHandler : IRequestHandler<CreateStaffRequestLoanCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestLoan> baseStaffRequestLoanRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IHubContext<Notifications> _hubContext;
        private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;
        private readonly IUtilRepository _utilRepository;
        public CreateStaffRequestLoanCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                    IBaseRepository<StaffRequestLoan> baseStaffRequestLoanRepository,
                                                    IBaseRepository<NotificationModel> baseNotificationRepository,
                                                    ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                    IStaffRequestRepository staffRequestRepository,
                                                    IMapper mapper,
                                                    IOptions<AppSettings> appSettings,
                                                    IHubContext<Notifications> hubContext,
                                                    IExactusEmpleadoRepository exactusEmpleadoRepository,
                                                    IUtilRepository utilRepository)
        {
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseStaffRequestLoanRepository = baseStaffRequestLoanRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
            _hubContext = hubContext;
            this.exactusEmpleadoRepository = exactusEmpleadoRepository;
            this._utilRepository = utilRepository;
        }
        public async Task<Result> Handle(CreateStaffRequestLoanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.StaffRequestLoan.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
                var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestLoan.StaffRequest);
                staffRequest.SetStatePending();
                await baseStaffRequestRepository.Add(staffRequest);
                var staffRequestLoan = mapper.Map<StaffRequestLoan>(request.StaffRequestLoan);
                staffRequestLoan.SetIdStaffRequest(staffRequest.Id);
                if (staffRequestLoan.DateLoan == null || staffRequestLoan.DateLoan == DateTime.MinValue)
                {
                    staffRequestLoan.DateLoan = DateTime.Now.AddDays(appSettings.DaysTimeLine); 
                }
                
                var urlhost = appSettings.PathSaveFile;

                var filenamefolder = Path.Combine(urlhost, "File\\");
                var Name = String.Format("{0}_PREST_{1}", staffRequest.Id, request.file.FileName);
                var Folder = filenamefolder + request.file.FileName;

                if (!Directory.Exists(filenamefolder))
                {
                    Directory.CreateDirectory(filenamefolder);
                }

                using (var stream = new FileStream(Folder, FileMode.Create))
                {
                    request.file.CopyTo(stream);
                }
                staffRequestLoan.PathFileDocument = Folder;
                
                await baseStaffRequestLoanRepository.Add(staffRequestLoan);
                var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
                if (request.StaffRequestLoan.DateLoan == null || request.StaffRequestLoan.DateLoan == DateTime.MinValue)
                {
                    request.StaffRequestLoan.DateLoan = DateTime.Now.AddDays(appSettings.DaysTimeLine);
                }


                decimal nrate = 0;
                var globalParameterExactus = await exactusEmpleadoRepository.GetExactusGlobalCCP("E_ALL");

                if (globalParameterExactus != null)
                {
                    nrate = globalParameterExactus.tasa_anual_local;
                }

                request.StaffRequestLoan.RateExactus = nrate;



                await typeStaffRequestApproverRepository.InsertLoanDetail(request.StaffRequestLoan, staffRequest.Id);
                await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
                if (approver != null)
                {
                    //Consular cargo por ID
                    ListChargePostulantDto cargos = await this._utilRepository.GetChangePositionById(staffRequest.IdCharge);
                    int idArea = cargos.nid_area;
                    //int idArea = approver.AllowApproveAll ? 0 : request.StaffRequestLoan.StaffRequest.StaffRequestEmployee.IdArea;
                    var receptorList = await staffRequestRepository.GetListReceptorForNotificationBoss(approver.IdProfile, idArea, staffRequest.IdEmployee);
                    var employee = request.StaffRequestLoan.StaffRequest.StaffRequestEmployee;
                    receptorList.ForEach(x =>
                    {
                        x.EmplyeeFullName = $"{employee.Names} {employee.LastName} {employee.MotherLastName}";
                        x.EmplyeeDni = employee.Dni;
                        x.RolName = employee.Charge;
                        x.IdStaffRequest = staffRequest.Id;
                    });
                    var notificationCreator = new NotificationCreator(request.StaffRequestLoan.GetIdPerson(),
                                                                      appSettings.StaffRequestNotificationTemplateHtml,
                                                                      appSettings.UrlStaffRequest,
                                                                      request.StaffRequestLoan.StaffRequest.TypeStaffRequest,
                                                                      receptorList,
                                                                      _hubContext);
                    await notificationCreator.GenerateNotification(1);
                    var notificationList = notificationCreator.Notificationlist;
                    await baseNotificationRepository.AddRange(notificationList);
                }
            }
            catch (Exception ex)
            {
                var _error = ex;
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }

}
