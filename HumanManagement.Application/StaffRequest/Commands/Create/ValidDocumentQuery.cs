using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class ValidDocumentQuery : IRequest<Result>
    {
        public ValidDocumentControllDto payload { get; set; }
    }
    public class ValidDocumentQueryHandler : IRequestHandler<ValidDocumentQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;
        private readonly IExactusMedicalRequestRepository medicalrequestRepository;
        private readonly IBaseRepository<EmployeeModel> baseEmployeeRepository;
        private readonly IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseEmpresaRepository;
        private readonly ILogger<ValidDocumentQueryHandler> _logger;

        public ValidDocumentQueryHandler(IRequestMedicalRepository requestMedicalRepository,
                                         IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                            IOptions<AppSettings> appSettings,
                                            IUnitOfWork unitWork,
                                            IExactusMedicalRequestRepository medicalrequestRepository,
                                            IBaseRepository<EmployeeModel> baseEmployeeRepository,
                                            IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseEmpresaRepository,
                                            ILogger<ValidDocumentQueryHandler> _logger
                                            )
        {
            this._requestMedicalRepository = requestMedicalRepository;
            _baseNotification = basenotify;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
            this.medicalrequestRepository = medicalrequestRepository;
            this.baseEmployeeRepository = baseEmployeeRepository;
            this.baseEmpresaRepository = baseEmpresaRepository;
            this._logger = _logger;
        }
        public async Task<Result> Handle(ValidDocumentQuery request, CancellationToken cancellationToken)
        {


            var valid = true;
            foreach (var item in request.payload.list)
            {
                if (item.nstate == 3)
                {
                    valid = false;
                }
            }


            foreach (var item in request.payload.list)
            {
                ValidDocumentMedicalDto dtodoc = new ValidDocumentMedicalDto
                {
                    nid = item.nid,
                    nstate = item.nstate
                };

                await _requestMedicalRepository.ValidDocument(dtodoc);
            }

            #region Enviar A Exactus
            if (valid)
            {

                var requestModel = await _requestMedicalRepository.MedicalById(request.payload.nid_medical);
                if (requestModel.bexistexatus == null || requestModel.bexistexatus == false)
                {
                    var employeeModel = await baseEmployeeRepository.Find(requestModel.nid_collaborator);
                    var companyModel = await baseEmpresaRepository.Find(employeeModel.IdCompany);

                    ExactusMedicalRequestInsSpDto dtoexactus = new ExactusMedicalRequestInsSpDto();

                    dtoexactus.Schema = companyModel.Schema;
                    dtoexactus.PSCONJUNTO = companyModel.Schema;
                    dtoexactus.PSUSUARIO = "sa";
                    dtoexactus.PSEMPLEADO = employeeModel.CodEmployee;
                    dtoexactus.PSTIPOACCION = requestModel.scodtypeaction;
                    dtoexactus.PDTFECHA = requestModel.ddateinitdm;
                    dtoexactus.PDTFECHARIGE = requestModel.ddateinitdm;
                    dtoexactus.PDTFECHAVENCE = requestModel.ddateenddm;
                    dtoexactus.PNDIASACCION = (requestModel.ddateenddm - requestModel.ddateinitdm).Days + 1;
                    dtoexactus.PSNOMINA = null;
                    dtoexactus.PSPUESTO = null;
                    dtoexactus.PSPLAZA = null;
                    dtoexactus.PSDEPARTAMENTO = null;
                    dtoexactus.PSCENTROCOSTO = null;
                    dtoexactus.PNSALARIOREFERENCIA = null;
                    dtoexactus.PSTIPOAUSENCIA = requestModel.scodtypeabsence;
                    dtoexactus.PSESTADOEMPLEADO = null;
                    dtoexactus.PSRUBRO1 = null;
                    dtoexactus.PSRUBRO2 = null;
                    dtoexactus.PSRUBRO3 = null;
                    dtoexactus.PSRUBRO4 = null;
                    dtoexactus.PSRUBRO5 = null;
                    dtoexactus.PSRUBRO6 = null;
                    dtoexactus.PSRUBRO7 = null;
                    dtoexactus.PSRUBRO8 = null;
                    dtoexactus.PSRUBRO9 = null;
                    dtoexactus.PSRUBRO10 = null;
                    dtoexactus.PSNOTAS = null;
                    try
                    {
                        _logger.LogInformation("Se procederá a enviar la solicitud de descanso a Exactus");

                        var mensajeExactus = await medicalrequestRepository.InsertMedicalRequestSP(dtoexactus);
                        if (string.IsNullOrEmpty(mensajeExactus.PSMENSAJEERROR) && mensajeExactus.PNNUMEROACCION > 0)
                        {
                            _logger.LogInformation("Se registró correctamente en exactus con Numero de accion: " + mensajeExactus.PNNUMEROACCION);
                            await _requestMedicalRepository.UpdateStatusExactus(requestModel.nid_medical, true, mensajeExactus.PNNUMEROACCION);
                        }
                        else
                        {
                            _logger.LogInformation("El SP retornó el siguiente mensaje:" + mensajeExactus.PSMENSAJEERROR);
                            await _requestMedicalRepository.UpdateStatusExactus(requestModel.nid_medical, false, 0);
                            return new Result
                            {
                                StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                                MessageError = new List<string>() {
                                    mensajeExactus.PSMENSAJEERROR
                            }
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                        _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);

                        await _requestMedicalRepository.UpdateStatusExactus(requestModel.nid_medical, false, 0);
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() {
                            "Ocurrió un error al enviar la solicitud a Exactus."
                            }
                        };
                    }
                }
            }
            #endregion

            int estado;
            if (valid)
            {
                estado = 5;

                Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                string fmt = File.ReadAllText(_appSettings.MedicalAccept);

                fmt = fmt.Replace("[URLEVALUATION]", "http://localhost:4200/#/humanmanagement/request-medical-config/" + request.payload.nid_medical);
                fmt = fmt.Replace("[NAME]", request.payload.sfullname);

                newNotification.IdArea = request.payload.idArea;
                newNotification.IdPerson = request.payload.emisorId;
                newNotification.IdReceptor = request.payload.receptorId;
                newNotification.Subject = "Solicitud de Descanso medico o Subsidio Aceptada";
                newNotification.Body = fmt;
                newNotification.SendDate = DateTime.Now;
                newNotification.Active = true;

                newNotification.Important = true;
                newNotification.Favorite = true;

                await _baseNotification.Add(newNotification);
            }
            else
            {
                estado = 4;

                Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                string fmt = File.ReadAllText(_appSettings.MedicalObservado);

                fmt = fmt.Replace("[URLEVALUATION]", "http://localhost:4200/#/humanmanagement/request-medical-config/" + request.payload.nid_medical);
                fmt = fmt.Replace("[NAME]", request.payload.sfullname);

                newNotification.IdArea = request.payload.idArea;
                newNotification.IdPerson = request.payload.emisorId;
                newNotification.IdReceptor = request.payload.receptorId;
                newNotification.Subject = "Solicitud de Descanso medico o Subsidio Observada";
                newNotification.Body = fmt;
                newNotification.SendDate = DateTime.Now;
                newNotification.Active = true;

                newNotification.Important = true;
                newNotification.Favorite = true;

                await _baseNotification.Add(newNotification);


            }



            ValidChangeStateMedical change = new ValidChangeStateMedical
            {
                nid_medical = request.payload.nid_medical,
                nstate = estado,
                ntype = request.payload.ntype
            };

            if (request.payload.nid_originmdical == 1037)
            {
                await _requestMedicalRepository.ChangeStateMedical(change);
            }
            else
            {
                if (request.payload.ntype==1006)
                {
                    await _requestMedicalRepository.ChangeStateMedicalEtapa1ToEtapa3(change);

                }
                else
                {
                    await _requestMedicalRepository.ChangeStateMedical(change);
                }

            }
           


            await _unitWork.Commit();
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
