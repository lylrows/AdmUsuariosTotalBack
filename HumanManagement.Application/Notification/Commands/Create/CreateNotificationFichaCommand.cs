using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;

using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Create
{
    public class CreateNotificationFichaCommand : IRequest<Result>
    {
        public NotificationFilterFichaDto _filter { get; set; }
        public class CreateNotificationFichaCommandHandler : IRequestHandler<CreateNotificationFichaCommand, Result>
        {
            private readonly AppSettings _appSettings;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly IUtilRepository _utilRepository;
            public CreateNotificationFichaCommandHandler(IOptions<AppSettings> appSettings,
                                    IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IUtilRepository utilRepository)
            {
                _appSettings = appSettings.Value;
                this._baseNotification = baseNotification;
                this._utilRepository = utilRepository;
            }
            public async Task<Result> Handle(CreateNotificationFichaCommand request, CancellationToken cancellationToken)
            {
                
                string fmt = File.ReadAllText(_appSettings.TemplateSendNotificationFichaPersonal);
                fmt = fmt.Replace("[CANDIDATO]", request._filter.CompleteName);
                

                if (request._filter.Level == 1)  
                {
                    if (request._filter.PostulantType == "EXTERNA") fmt = fmt.Replace("[URL_DETAIL]", string.Format(_appSettings.UrlPostulantEvaluationExterna, request._filter.IdEvaluation));
                    else fmt = fmt.Replace("[URL_DETAIL]", string.Format(_appSettings.UrlPostulantEvaluationInterna, request._filter.IdEvaluation));
                } else fmt = fmt.Replace("[URL_DETAIL]", _appSettings.UrlPostulantAdministration);

                var listPersons = await _utilRepository.GetPersonsToSendFichaNotification(request._filter);
                foreach (var _person in listPersons)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();
                    newNotification.IdArea = _person.IdArea;
                    newNotification.IdPerson = request._filter.Level == 1 ? 4436: request._filter.IdPostulant;
                    newNotification.IdReceptor = _person.IdPerson;
                    newNotification.Subject = string.Format("Ficha de Personal {0} - Pendiente por Revisar", CultureInfo.InvariantCulture.TextInfo.ToTitleCase(request._filter.PostulantType)); 
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;
                    newNotification.Important = false;
                    newNotification.Favorite = false;
                    await _baseNotification.Add(newNotification);
                }              

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    MessageError = new List<string>() { "Se agrego la notificación de manera correcta." }
                };
            }
        }
    }
}
