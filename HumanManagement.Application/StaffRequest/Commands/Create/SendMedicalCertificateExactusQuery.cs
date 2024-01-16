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

    public class SendMedicalCertificateExactusQuery : IRequest<Result>
    {
        public ValidDocumentControllDto payload { get; set; }
    }
    public class SendMedicalCertificateExactusQueryHandler : IRequestHandler<SendMedicalCertificateExactusQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        
        private readonly IExactusMedicalRequestRepository medicalrequestRepository;
        private readonly IBaseRepository<EmployeeModel> baseEmployeeRepository;
        private readonly IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseEmpresaRepository;
        private readonly ILogger<ValidDocumentQueryHandler> _logger;

        public SendMedicalCertificateExactusQueryHandler(IRequestMedicalRepository requestMedicalRepository,
                                            
                                            IExactusMedicalRequestRepository medicalrequestRepository,
                                            IBaseRepository<EmployeeModel> baseEmployeeRepository,
                                            IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseEmpresaRepository,
                                            ILogger<ValidDocumentQueryHandler> _logger
                                            )
        {
            this._requestMedicalRepository = requestMedicalRepository;
            
            this.medicalrequestRepository = medicalrequestRepository;
            this.baseEmployeeRepository = baseEmployeeRepository;
            this.baseEmpresaRepository = baseEmpresaRepository;
            this._logger = _logger;
        }
        public async Task<Result> Handle(SendMedicalCertificateExactusQuery request, CancellationToken cancellationToken)
        {
            
            int isSendStatus = 0;
            #region Enviar A Exactus
            

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
                    dtoexactus.PNDIASACCION = (requestModel.ddateenddm - requestModel.ddateinitdm).Days +1;
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
                            isSendStatus = 1;
                        }
                        else
                        {
                            _logger.LogInformation("El SP retornó el siguiente mensaje:" + mensajeExactus.PSMENSAJEERROR);
                            await _requestMedicalRepository.UpdateStatusExactus(requestModel.nid_medical, false, 0);
                             isSendStatus = 3;
                            return new Result
                            {
                                Data= isSendStatus,
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
                        isSendStatus = 0;
                        return new Result
                        {
                            Data= isSendStatus,
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() {
                            "Ocurrió un error al enviar la solicitud a Exactus."
                            }
                        };
                    }
                    
                }
                else
                {
                    isSendStatus = 2; 
                }
               
            
            #endregion
            return new Result
            {
                Data = isSendStatus,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
