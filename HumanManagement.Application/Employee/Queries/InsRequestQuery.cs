using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class InsRequestQuery : IRequest<Result>
    {
        public RequestInsDto payload { get; set; }
        public IFormFile file { get; set; }
        public class InsRequestQueryHandler : IRequestHandler<InsRequestQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly AppSettings _appSettings;
            public InsRequestQueryHandler(IRquestRepository employeeRepository, IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings)
            {
                this._employeeRepository = employeeRepository;
                this._baseNotification = baseNotification;
                _appSettings = appSettings.Value;
            }

            public async Task<Result> Handle(InsRequestQuery query, CancellationToken cancellationToken)
            {
                int result = await _employeeRepository.InsertRequestEmployee(query.payload,query.file);

                var list = await _employeeRepository.GetPersonByAdminPerson();

                foreach(var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RegisterRequestTemplateHtml);

                    switch (query.payload.ntypeseccion)
                    {
                        case 1:
                            fmt = fmt.Replace("[SOLICITUD]", "Dirección");
                            break;
                        case 2:
                            fmt = fmt.Replace("[SOLICITUD]", "Teléfono");
                            break;
                        case 3:
                            fmt = fmt.Replace("[SOLICITUD]", "Estado Civil");
                            break;
                        case 4:
                            fmt = fmt.Replace("[SOLICITUD]", "Licencias");
                            break;
                        case 5:
                            fmt = fmt.Replace("[SOLICITUD]", "Estudio");
                            break;
                        case 6:
                            fmt = fmt.Replace("[SOLICITUD]", "Esposa/Conviviente");
                            break;
                        case 7:
                            fmt = fmt.Replace("[SOLICITUD]", "Hijos");
                            break;
                    }

                    fmt = fmt.Replace("[EVALUATEDNAME]", item.sfullname);
                    fmt = fmt.Replace("[URLEVALUATION]", "http://localhost:4200/#/humanmanagement/staffadministration"+"?id="+ result.ToString());

                    newNotification.IdArea = 13;
                    newNotification.IdPerson = query.payload.nid_person;
                    newNotification.IdReceptor = item.nid_person;
                    newNotification.Subject = "Nueva Solicitud de Movimiento de Datos";
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
