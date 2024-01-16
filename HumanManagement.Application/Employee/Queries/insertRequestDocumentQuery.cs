using DocumentFormat.OpenXml.Office2010.Excel;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class insertRequestDocumentQuery : IRequest<Result>
    {
        public InsertRequestDocumentDto payload { get; set; }
        public class insertRequestDocumentQueryHandler : IRequestHandler<insertRequestDocumentQuery, Result>
        {
            
            private readonly IRquestRepository _requestRepository;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly AppSettings _appSettings;
            private readonly ILogger<insertRequestDocumentQueryHandler> _logger;
            private readonly IEmployeeRepository _employeeRepository;

            public insertRequestDocumentQueryHandler(IRquestRepository requestRepository, IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings, ILogger<insertRequestDocumentQueryHandler> logger,
                                    IEmployeeRepository employeeRepository)
            {
                this._requestRepository = requestRepository;
                this._baseNotification = baseNotification;
                _appSettings = appSettings.Value;
                this._logger = logger;
                this._employeeRepository = employeeRepository;
            }
           
            public async Task<Result> Handle(insertRequestDocumentQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("nid_collaborador: " + query.payload.nid_collaborador);
                    int nid_request = 0;
                    nid_request = await _requestRepository.InsertRequestDocument(query.payload);


                    _logger.LogInformation("nid_request: " + nid_request);

                    var objrequest = await _employeeRepository.GetDataToSendDownloadDocument(nid_request);

                    var list = await _requestRepository.GetPersonByAdminPerson();

                    foreach (var item in list)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();
                        _logger.LogInformation($"_appSettings.DownloadRequestDocumentHtml: {_appSettings.DownloadRequestDocumentHtml}");

                        string fmt = File.ReadAllText(_appSettings.DownloadRequestDocumentHtml);

                        fmt = fmt.Replace("[SOLICITUD]", $"Descarga documento de {objrequest.tipo_solicitud}");
                        fmt = fmt.Replace("[EMPRESA]", objrequest.empresa_nombre);
                        fmt = fmt.Replace("[PERIODO]", objrequest.periodo);
                        fmt = fmt.Replace("[TIPO_SOLICITUD]", objrequest.tipo_solicitud);

                        newNotification.IdArea = item.nid_area;
                        newNotification.IdPerson = objrequest.nid_person; 
                        newNotification.IdReceptor = item.nid_person;
                        newNotification.Subject = $"Descarga de Documento: {objrequest.tipo_solicitud} {objrequest.periodo} {objrequest.empresa_nombre}"; 
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);
                    }
                    _logger.LogInformation("nid_request: " + nid_request);

                    return new Result
                    {
                        StateCode = 200,
                        Data = new { nid_request = nid_request, messaje = "Acción realizada con éxito" }
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError("Message: " + ex.Message);
                    _logger.LogError("StackTrace: " + ex.StackTrace);
                    _logger.LogError("TargetSite: " + ex.TargetSite);
                    return new Result
                    {
                        StateCode = 500,
                        Data = new { nid_request = 0, messaje = ex.Message }
                    };
                    throw;
                }
            }
        }
   
    }
}
