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
    public class DownloadRequestDocumentQuery : IRequest<Result>
    {
        public InsertRequestDocumentDto payload { get; set; } 
        public class DownloadRequestDocumentQueryHandler : IRequestHandler<DownloadRequestDocumentQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly AppSettings _appSettings;
            private readonly ILogger<DownloadRequestDocumentQueryHandler> _logger;
            public DownloadRequestDocumentQueryHandler(IRquestRepository employeeRepository, IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings,
                                    ILogger<DownloadRequestDocumentQueryHandler> _logger)
            {
                this._employeeRepository = employeeRepository;
                this._baseNotification = baseNotification;
                _appSettings = appSettings.Value;
                this._logger = _logger;
            }
            
            public async Task<Result> Handle(DownloadRequestDocumentQuery query, CancellationToken cancellationToken)
            {
                int nid_request = 0;

                var list = await _employeeRepository.GetPersonByAdminPerson();

                foreach (var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();
                    _logger.LogInformation($"_appSettings.DownloadRequestDocumentHtml: {_appSettings.DownloadRequestDocumentHtml}");

                    string fmt = File.ReadAllText(_appSettings.DownloadRequestDocumentHtml);


                    fmt = fmt.Replace("[SOLICITUD]", $"Descarga documento de {query.payload.tipo_solicitud}");
                    fmt = fmt.Replace("[EMPRESA]", query.payload.empresa_nombre);
                    fmt = fmt.Replace("[PERIODO]", query.payload.periodo);
                    fmt = fmt.Replace("[TIPO_SOLICITUD]", query.payload.tipo_solicitud);

                    newNotification.IdArea = item.nid_area;
                    newNotification.IdPerson = query.payload.nid_person;
                    newNotification.IdReceptor = item.nid_person;
                    newNotification.Subject = $"Descarga de Documento: {query.payload.tipo_solicitud} - {query.payload.periodo} - {query.payload.empresa_nombre}";
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;

                    newNotification.Important = true;
                    newNotification.Favorite = true;

                    await _baseNotification.Add(newNotification);
                }

                return new Result
                {
                    StateCode = 200,
                    Data = new { nid_request = nid_request, messaje = "Acción realizada con éxito" }
                };
            }
        }


    }
}
