using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Notification.Dto;

using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

using System.Threading; 
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.EvaluationPostulant;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;

namespace HumanManagement.Application.Notification.Commands.Create
{
    public class CreateNotificationNotSelectedPostulantCommand : IRequest<Result> 
    {
        public SendNotificationNotSeltectedDto Notification { get; set; }
    }

    public class CreateNotificationNotSelectedPostulantCommandHandler : IRequestHandler<CreateNotificationNotSelectedPostulantCommand, Result>
    {
        private readonly AppSettings _appSettings;
        private readonly IMailRepository mailRepository;
        private readonly IBaseRepository<EvaluationModel> evaPostBaseRepository;
        private readonly IBaseRepository<Domain.EvaluationPostulant.Models.Evaluation> evaBaseRepository;
        private readonly IBaseRepository<EvaluationVacantInternal> evatInternaBaseRepository;
        private readonly IBaseRepository<EvaluationPostulantsInternalModel> evaPostInternaBaseRepository;
        private readonly HumanManagement.Domain.Postulant.Person.Contracts.IPersonRepository personbaseRepository;
        private readonly IBaseRepository<Job> jobbaseRepository;
        private readonly HumanManagement.Domain.Person.Contracts.IPersonRepository personbaseInternaRepository;
        private readonly ILogger<CreateNotificationNotSelectedPostulantCommandHandler> _logger;

        public CreateNotificationNotSelectedPostulantCommandHandler(
                                    IOptions<AppSettings> appSettings,
                                    IMailRepository mailRepository,
                                    IBaseRepository<EvaluationModel> evaPostBaseRepository,
                                    IBaseRepository<Domain.EvaluationPostulant.Models.Evaluation> evaBaseRepository,
                                    IBaseRepository<EvaluationPostulantsInternalModel> evaPostInternaBaseRepository,
                                    IBaseRepository<EvaluationVacantInternal> evatInternaBaseRepository,
                                    IBaseRepository<Job> jobbaseRepository,
                                    HumanManagement.Domain.Postulant.Person.Contracts.IPersonRepository personbaseRepository,
                                    HumanManagement.Domain.Person.Contracts.IPersonRepository personbaseInternaRepository,
                                    ILogger<CreateNotificationNotSelectedPostulantCommandHandler> _logger
            )
        {
            _appSettings = appSettings.Value;
            this.mailRepository = mailRepository;
            this.evaPostBaseRepository = evaPostBaseRepository;
            this.evaBaseRepository = evaBaseRepository;
            this.evaPostInternaBaseRepository = evaPostInternaBaseRepository;
            this.evatInternaBaseRepository = evatInternaBaseRepository;
            this.personbaseRepository = personbaseRepository;
            this.personbaseInternaRepository = personbaseInternaRepository;
            this.jobbaseRepository = jobbaseRepository;
            this._logger = _logger;
        }

        public async Task<Result> Handle(CreateNotificationNotSelectedPostulantCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                string _position = string.Empty;
                int _estadoSeleccionado = 911;
                if (request.Notification.Type == "Externa")
                {
                    var evaluation = await evaBaseRepository.FindPredicate(x => x.Id == request.Notification.IdEvaluation);
                    var job = await jobbaseRepository.FindPredicate(x => x.Id_Job == evaluation.IdJob);

                    _position = evaluation.PositionRequired;
                    var listaEvaluations = await evaPostBaseRepository.FindAllPredicate(x => x.IdEvaluation == request.Notification.IdEvaluation);
                    foreach (var _item in listaEvaluations)
                    {
                        if (_item.State == _estadoSeleccionado) continue;
                        var person = await personbaseRepository.GetPerson(_item.IdPostulant);
                        if (person != null)
                        {
                            if (IsValidEmail(person.Email)) await SendMailPostulantNotSelected(person.FirstName, person.LastName, person.Email, _position, _appSettings.PostulantNotSelectedExternaTemplateHtml, job.Id_Company);
                        }
                    }
                }
                else
                {
                    var evaluationInterna = await evatInternaBaseRepository.FindPredicate(x => x.Id == request.Notification.IdEvaluation);
                    _position = evaluationInterna.PositionRequired;
                    var listaEvaluationsInterna = await evaPostInternaBaseRepository.FindAllPredicate(x => x.IdEvaluation == request.Notification.IdEvaluation);
                    foreach (var _item in listaEvaluationsInterna)
                    {
                        if (_item.State == _estadoSeleccionado) continue;
                        var person = await personbaseInternaRepository.GetPerson(_item.IdPostulant);
                        if (person != null)
                        {
                            if (IsValidEmail(person.email)) await SendMailPostulantNotSelected(person.sfirstname, person.slastname, person.email, _position, _appSettings.PostulantNotSelectedTemplateHtml, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(string.Format("CreateNotificationNotSelectedPostulantCommandHandler => {0}", ex.Message));
                _logger.LogInformation(string.Format("CreateNotificationNotSelectedPostulantCommandHandler => {0}", ex.StackTrace));
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    MessageError = new List<string>() { "Ocurrio un error al enviar la notificación" }

                };
            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se envio la notificación correctamente" }

            };
        }

        bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SendMailPostulantNotSelected(String firstName, String lastName, String email, String position, string templateHtml, int? idCompany)
        {


            
            string url_background_image = _appSettings.PostulantNotSelectedExternaBackground;
            var arrayColorButton = _appSettings.PostulantNotSelectedExternaColorButton.Split(',');
            string color_button = string.Empty;

            switch (idCompany)
            {
                case 1:
                    url_background_image = string.Format(url_background_image, "CampoFe");
                    color_button = arrayColorButton[0];
                    break;
                case 2:
                    url_background_image = string.Format(url_background_image, "PrestaFe");
                    color_button = arrayColorButton[1];
                    break;
                case 3:
                    url_background_image = string.Format(url_background_image, "FeSalud");
                    color_button = arrayColorButton[2];
                    break;
                case 4:
                    url_background_image = string.Format(url_background_image, "GrupoFe");
                    color_button = arrayColorButton[3];
                    break;
            }

            string template = await File.ReadAllTextAsync(templateHtml);
            template = template.Replace("[COLOR_BUTTON]", color_button);
            template = template.Replace("[BACKGROUND-IMAGE]", url_background_image);
            template = template.Replace("[USER]", firstName);
            template = template.Replace("[CHARGE]", position);
            template = template.Replace("[URL_PERCEPCION]", _appSettings.PostulantNotSelectedExternaUrlPercepcion);

            var mailRequest = new MailRequestDto
            {
                Message = new MessageDto
                {
                    Body = new BodyDto
                    {
                        Format = EnumBodyMail.Html,
                        Value = template
                    },
                    Subject = "Proceso de Selección Grupo Fe"
                },
                From = _appSettings.FromMailNotification,
                FromName = _appSettings.FromNameNotification,
                To =
                {
                    email
                },
                Cc = null
            };

            var result = await mailRepository.SendMail(mailRequest);

            return result;
        }
    }
}
