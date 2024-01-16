using AutoMapper;
using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Empresa.Dto;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Enum;
using HumanManagement.Domain.StaffRequest.Events;
using HumanManagement.Domain.StaffRequest.Models;
using HumanManagement.Domain.WindowsService.ServerUs.Contracts;
using HumanManagement.Domain.WindowsService.ServerUs.Dto;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class ApproveStaffRequestCommand : IRequest<Result>
    {
        public StaffRequestApproverDto StaffRequestApprover { get; set; }
    }
    public class ApproveStaffRequestCommandHandler : IRequestHandler<ApproveStaffRequestCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestApprover> baseRepository;
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly SessionManager sessionManager;
        private readonly IBaseRepository<Domain.Employee.Models.EmployeeModel> baseEmployee;

        
        private readonly IBaseRepository<StaffRequestVacation> baseRepositoryVacation;
        private readonly IBaseRepository<StaffRequestPermit> baseRepositoryPermit;
        private readonly IBaseRepository<StaffRequestAbsence> baseRepositoryAbsence;
        private readonly IBaseRepository<StaffRequestJustificationTardiness> baseRepositoryJustTardiness;

        private readonly IEmpresaRepository empresaRepository;
        private readonly ISUMovAsistenciaCabRepository movAsistenciaCabRepository;
        private readonly ISUMovAsistenciaDetRepository movAsistenciaDetRepository;
        private readonly ILogger<ApproveStaffRequestCommandHandler> _logger;
        private readonly IBaseRepository<PermitType> basepermitTypeRepository;
        private readonly IBaseRepository<TypeAbsence> basetypeAbsense;

        private readonly IBaseRepository<HumanManagement.Domain.Cargo.Models.Cargo> baseCargoRepository;
        private readonly IBaseRepository<HumanManagement.Domain.Areas.Models.Areas> baseAreasRepository;
        private readonly IHubContext<Notifications> _hubContext;



        public ApproveStaffRequestCommandHandler(IBaseRepository<StaffRequestApprover> baseRepository,
                                                        IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<NotificationModel> baseNotificationRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                        IMapper mapper,
                                                        IOptions<AppSettings> appSettings,
                                                        SessionManager sessionManager,
                                                        IBaseRepository<Domain.Employee.Models.EmployeeModel> baseEmployee,

                                                        IBaseRepository<StaffRequestVacation> baseRepositoryVacation,
                                                        IBaseRepository<StaffRequestPermit> baseRepositoryPermit,
                                                        IBaseRepository<StaffRequestAbsence> baseRepositoryAbsence,
                                                        IBaseRepository<StaffRequestJustificationTardiness> baseRepositoryJustTardiness,
                                                        IEmpresaRepository empresaRepository,
                                                        ISUMovAsistenciaCabRepository movAsistenciaCabRepository,
                                                        ISUMovAsistenciaDetRepository movAsistenciaDetRepository,
                                                        ILogger<ApproveStaffRequestCommandHandler> _logger,
                                                        IBaseRepository<PermitType> basepermitTypeRepository,
                                                        IBaseRepository<HumanManagement.Domain.Cargo.Models.Cargo> baseCargoRepository,
                                                         IBaseRepository<HumanManagement.Domain.Areas.Models.Areas> baseAreasRepository,
                                                         IHubContext<Notifications> hubContext,
                                                         IBaseRepository<TypeAbsence> basetypeAbsense
                                                        )
        {
            this.baseRepository = baseRepository;
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
            this.sessionManager = sessionManager;
            this.baseEmployee = baseEmployee;

            this.baseRepositoryVacation = baseRepositoryVacation;
            this.baseRepositoryPermit = baseRepositoryPermit;
            this.baseRepositoryAbsence = baseRepositoryAbsence;
            this.baseRepositoryJustTardiness = baseRepositoryJustTardiness;
            this.empresaRepository = empresaRepository;
            this.movAsistenciaCabRepository  = movAsistenciaCabRepository;
            this.movAsistenciaDetRepository = movAsistenciaDetRepository;
            this._logger = _logger;
            this.basepermitTypeRepository = basepermitTypeRepository;
            this.baseCargoRepository = baseCargoRepository;
            this.baseAreasRepository = baseAreasRepository;
            _hubContext = hubContext;
            this.basetypeAbsense = basetypeAbsense;
        }
        public async Task<Result> Handle(ApproveStaffRequestCommand request, CancellationToken cancellationToken)
        {
            var staffRequestApprover = mapper.Map<StaffRequestApprover>(request.StaffRequestApprover);
            var userLogged = sessionManager.User;
            staffRequestApprover.IdEmployee = userLogged.IdEmployee;
            staffRequestApprover.IdProfile = userLogged.IdProfile;
            int totalLevel = await typeStaffRequestApproverRepository.GetTotalLevels(request.StaffRequestApprover.IdTypeStaffRequest);
            var requestStatusChecker = new RequestStatusChecker(totalLevel, staffRequestApprover.Level);
            requestStatusChecker.SetStateApproved();
            var staffRequest = new StaffRequestModel
            {
                Id = staffRequestApprover.IdStaffRequest
            };
            staffRequest.SetState(requestStatusChecker.State);
            staffRequestApprover.SetState((int)StaffRequestState.APPROVED);
            staffRequest.SetComment(staffRequestApprover.Comment);
            await baseRepository.Add(staffRequestApprover); 
            await baseStaffRequestRepository.UpdatePartial(staffRequest, x => x.State, x => x.Comment);
            var typeStaffRequest = await baseTypeStaffRequestRepository.Find(request.StaffRequestApprover.IdTypeStaffRequest);
            var approver = await typeStaffRequestApproverRepository.GetByLevel(request.StaffRequestApprover.IdTypeStaffRequest, request.StaffRequestApprover.Level + 1);
            var requestEmployee = await staffRequestRepository.GetById(request.StaffRequestApprover.IdStaffRequest);
            var employeeColaborator = requestEmployee.StaffRequestEmployee;
            await typeStaffRequestApproverRepository.AproveLevelRequest(staffRequestApprover);  
            if (approver != null)
            {
                //int idArea = approver.AllowApproveAll ? 0 : employeeColaborator.IdArea;
                int idArea = employeeColaborator.IdArea;
                var receptorList = await staffRequestRepository.GetListReceptorForNotification(approver.IdProfile, idArea);
                receptorList.ForEach(x =>
                {
                    x.EmplyeeFullName = $"{employeeColaborator.Names} {employeeColaborator.LastName} {employeeColaborator.MotherLastName}";
                    x.EmplyeeDni = employeeColaborator.Dni;
                    x.RolName = employeeColaborator.Charge;
                    x.IdStaffRequest = staffRequest.Id;
                });
                var notificationCreator = new NotificationCreator(userLogged.IdPerson,
                                                                  appSettings.StaffRequestNotificationTemplateHtml,
                                                                  appSettings.UrlStaffRequest,
                                                                  typeStaffRequest.Name,
                                                                  receptorList, _hubContext);
                await notificationCreator.GenerateNotification(1);
                var notificationList = notificationCreator.Notificationlist;
                await baseNotificationRepository.AddRange(notificationList);
            }
            else
            {
                var receptorList = new List<NotificationReceptorDto>();
                receptorList.Add(new NotificationReceptorDto
                {
                    IdArea = employeeColaborator.IdArea,
                    IdReceptor = employeeColaborator.IdPerson,
                    EmplyeeFullName = $"{employeeColaborator.Names} {employeeColaborator.LastName} {employeeColaborator.MotherLastName}",
                    EmplyeeDni = employeeColaborator.Dni,
                    RolName = employeeColaborator.Charge,
                    IdStaffRequest = staffRequest.Id
                });
                var notification = new NotificationCreator(userLogged.IdPerson,
                                                            appSettings.StaffRequestNotificationAcceptTemplateHtml,
                                                            appSettings.UrlStaffRequest,
                                                            typeStaffRequest.Name,
                                                            receptorList, _hubContext);
                await notification.GenerateNotification(2);
                var notificationList = notification.Notificationlist;
                await baseNotificationRepository.AddRange(notificationList);
            }

            #region Registrar en Serverus
            if (staffRequest.State == (int)StaffRequestState.APPROVED)
            {
                _logger.LogInformation("Se Registrará en Serverus");
                try
                {
                    #region seteo de dto 
                    _logger.LogInformation("Obteniendo el HeaderRequest");
                    var SolicitudCab = await staffRequestRepository.GetById(staffRequestApprover.IdStaffRequest);
                    _logger.LogInformation("Buscando el empleado: " + SolicitudCab.StaffRequestEmployee.IdEmployee);
                    var EmployeBD = baseEmployee.Find(SolicitudCab.StaffRequestEmployee.IdEmployee).Result;

                    var PuestoBD = baseCargoRepository.Find(EmployeBD.IdPosition).Result;

                    var AreaBD = baseAreasRepository.Find(PuestoBD.IdArea).Result;


                    _logger.LogInformation("EmployeBD.IdCompany: " + EmployeBD.IdCompany);

                    SURegisterAsistenciaDto asistenciaDto = new SURegisterAsistenciaDto();
                    asistenciaDto.IdCompany = EmployeBD.IdCompany;
                    asistenciaDto.SetCodRequestServerus(request.StaffRequestApprover.IdTypeStaffRequest);



                    switch (request.StaffRequestApprover.IdTypeStaffRequest)
                    {
                        case (int)StaffRequestType.VACATION_WITHOUT_EXCEPTION:
                        case (int)StaffRequestType.VACATION_WITH_EXCEPTION:

                            _logger.LogInformation("Se registrará una solicitud de tipo vacación");
                            var vacationBD = baseRepositoryVacation.Find(staffRequestApprover.IdStaffRequest).Result;

                            var dinicio = new DateTime(vacationBD.StartVacation.Year, vacationBD.StartVacation.Month, vacationBD.StartVacation.Day, 8, 0, 0);
                            var dFin = new DateTime(vacationBD.EndVacation.Year, vacationBD.EndVacation.Month, vacationBD.EndVacation.Day, 18, 0, 0);

                            asistenciaDto.fecha_hora_inicio = dinicio;
                            asistenciaDto.fecha_hora_final = dFin;
                            asistenciaDto.fecha_hora_inicio_real = dinicio;
                            asistenciaDto.fecha_hora_final_real = dFin;

                            asistenciaDto.FechaSolicitud = dinicio;

                            _logger.LogInformation("Se terminó de setear los datos");
                            break;
                        case (int)StaffRequestType.PERMIT:

                            _logger.LogInformation("Se registrará una solicitud de tipo Permiso");
                            var PermitBD = baseRepositoryPermit.Find(staffRequestApprover.IdStaffRequest).Result;
                            var PermitTypeBD = basepermitTypeRepository.Find(PermitBD.IdPermitType).Result;

                            asistenciaDto.FechaSolicitud = PermitBD.PermitDate;
                            asistenciaDto.fecha_hora_inicio = PermitBD.StartTime;
                            asistenciaDto.fecha_hora_final = PermitBD.EndTime;
                            asistenciaDto.fecha_hora_inicio_real = PermitBD.StartTime;
                            asistenciaDto.fecha_hora_final_real = PermitBD.EndTime;
                            asistenciaDto.CodTipoSolicitud = PermitTypeBD.scod_type_request;
                            asistenciaDto.CodSubTipoSolicitud = PermitTypeBD.scodsub_type_request;
                            _logger.LogInformation("Se terminó de setear los datos");
                            break;
                        case (int)StaffRequestType.JUSTIFICATION_FOR_ABSENCE:

                            _logger.LogInformation("Se registrará una solicitud de tipo Ausencia");
                            var AbsenseBD = baseRepositoryAbsence.Find(staffRequestApprover.IdStaffRequest).Result;
                            var absensetypebd = basetypeAbsense.Find(AbsenseBD.IdTypeAbsence).Result;

                            asistenciaDto.FechaSolicitud = AbsenseBD.DateAbsence;
                            asistenciaDto.fecha_hora_inicio = AbsenseBD.StartTime;
                            asistenciaDto.fecha_hora_final = AbsenseBD.EndTime;
                            asistenciaDto.fecha_hora_inicio_real = AbsenseBD.StartTime;
                            asistenciaDto.fecha_hora_final_real = AbsenseBD.EndTime;
                            asistenciaDto.CodTipoSolicitud = absensetypebd.scod_type_request;
                            asistenciaDto.CodSubTipoSolicitud = absensetypebd.scodsub_type_request;

                            _logger.LogInformation("Se terminó de setear los datos");

                            break;
                        case (int)StaffRequestType.JUSTIFICATION_FOR_DELAY:

                            _logger.LogInformation("Se registrará una solicitud de tipo Tardanza");
                            var DelayBD = baseRepositoryJustTardiness.Find(staffRequestApprover.IdStaffRequest).Result;

                            asistenciaDto.FechaSolicitud = DelayBD.tardinessDate;
                            asistenciaDto.fecha_hora_inicio = DelayBD.StartTime;
                            asistenciaDto.fecha_hora_final = DelayBD.EndTime;
                            asistenciaDto.fecha_hora_inicio_real = DelayBD.StartTime;
                            asistenciaDto.fecha_hora_final_real = DelayBD.EndTime;

                            _logger.LogInformation("Se terminó de setear los datos");
                            break;
                        default:
                            
                            break;
                    }

                    asistenciaDto.CentroResponsabilidad = EmployeBD.CenterCost;


                    asistenciaDto.CodEmpleado = EmployeBD.CodEmployee;



                    asistenciaDto.DescripcionSolcitud = typeStaffRequest.Description;
                    #endregion



                    
                    List<EmpresaDto> CompaniesList = empresaRepository.GetAll().Result;

                    int? nIdIdentidad = CompaniesList.Find(i => i.Id == asistenciaDto.IdCompany).IdServerUs;
                    if (nIdIdentidad == null)
                    {
                        _logger.LogInformation("No hay un ididentidad (empresa) de serverus  configurada  en el portal de gestión humana");
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.STATE_CODE_OK
                        };
                    }

                    SUGetNewIdFilterDto newidFilterDto = new SUGetNewIdFilterDto();
                    newidFilterDto.cod_tipo_solicitud = asistenciaDto.CodTipoSolicitud;
                    newidFilterDto.identidad = nIdIdentidad ?? 0; 
  
                    _logger.LogInformation("Obtener  Id del colaborador ==>");
                    _logger.LogInformation("newidFilterDto.identidad: " + newidFilterDto.identidad.ToString());
                    _logger.LogInformation("newidFilterDto.CodEmpleado: " + asistenciaDto.CodEmpleado.ToString());



                    ServerUsInsPermSPDto dtoinsert = new ServerUsInsPermSPDto();

                    dtoinsert.ai_identidad = nIdIdentidad ?? 0;
                    dtoinsert.as_cod_tipo_solicitud = asistenciaDto.CodTipoSolicitud;
                    dtoinsert.as_cod_centroresp = asistenciaDto.CentroResponsabilidad;
                    dtoinsert.as_numero_documento = asistenciaDto.CodEmpleado;
                    dtoinsert.as_cod_subtipo_solicitud = asistenciaDto.CodSubTipoSolicitud;
                    dtoinsert.adt_fch_movimiento = asistenciaDto.fecha_hora_inicio;
                    dtoinsert.adt_fch_horas_inicio = asistenciaDto.fecha_hora_inicio;
                    dtoinsert.adt_fch_horas_final = asistenciaDto.fecha_hora_final;
                    dtoinsert.adt_fch_hora_ini_real = asistenciaDto.fecha_hora_inicio_real;
                    dtoinsert.adt_fch_hora_fin_real = asistenciaDto.fecha_hora_final_real;

                    bool bRegInServerus = await movAsistenciaCabRepository.InsertPermSP(dtoinsert);

                }
                catch (Exception ex)
                {
                    _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                    _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);

                }

            }

            #endregion



            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }


    }
}
