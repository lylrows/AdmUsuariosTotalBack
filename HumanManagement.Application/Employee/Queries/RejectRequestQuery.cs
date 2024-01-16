using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class RejectRequestQuery : IRequest<Result>
    {
        public RejectRequest payload { get; set; }
        public class RejectRequestQueryHandler : IRequestHandler<RejectRequestQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly AppSettings _appSettings;
            public RejectRequestQueryHandler(IRquestRepository employeeRepository, IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings)
            {
                _employeeRepository = employeeRepository;
                 this._baseNotification = baseNotification;
                this._appSettings = appSettings.Value;
            }

            public async Task<Result> Handle(RejectRequestQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.RejectRequest(query.payload);

                if ( query.payload.type == 12 )
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RejectRequestTemplateHtml);


                    newNotification.IdArea = query.payload.nid_area;
                    newNotification.IdPerson = query.payload.nid_collaborator;
                    newNotification.IdReceptor = query.payload.nid_reseptor;
                    newNotification.Subject = "Solicitud de Movimiento de Datos Rechazada";
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;

                    newNotification.Important = true;
                    newNotification.Favorite = true;

                    await _baseNotification.Add(newNotification);
                }

                if ( query.payload.type == 13 )
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RejectRequestDocumentTemplateHtml);


                    newNotification.IdArea = query.payload.nid_area;
                    newNotification.IdPerson = query.payload.nid_collaborator;
                    newNotification.IdReceptor = query.payload.nid_reseptor;
                    newNotification.Subject = "Solicitud de Consulta de Documentos Rechazada";
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
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
