using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;

using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using MediatR;
using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.IO;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Commands.Create
{
    public class SendNotificationCommand : IRequest<Result>
    {
        public EvaluationPostulantDto dto;
        public int IdCampaign { get; set; }
        public int tipo { get; set; }
    }

    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, Result>
    {
        private readonly AppSettings _appSettings;
        private readonly IMailRepository _mailRepository;
        private readonly IEvaluationRepository _evaluationRepository;

        public SendNotificationCommandHandler( IOptions<AppSettings> appSettings
            , IMailRepository mailRepository, IEvaluationRepository evaluationRepository)
        {
            _appSettings = appSettings.Value;
            this._mailRepository = mailRepository;
            this._evaluationRepository = evaluationRepository;
        }

        public async Task<Result> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var tipo = request.tipo;
            if (tipo == 0)
            {
                var listaevaluaciones = await _evaluationRepository.GetEvaluationsMail(request.IdCampaign);
                foreach (var eval in listaevaluaciones)
                {
                    string fmt = File.ReadAllText(_appSettings.InviteEvaluationTemplateHtml);

                    fmt = fmt.Replace("[CAMPAIGNNAME]", eval.CampaignName);
                    fmt = fmt.Replace("[EVALUATEDNAME]", eval.NameEvaluated);
                    fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + eval.IdEvaluation);
                    
                     await SendMailEvaluation("dany.delacruz@efitec.pe", fmt, eval.CampaignName);
                }
            }
            else if(tipo == 1)
            {
                string fmt = "";
                switch (request.dto.IdCompany)
                {                    
                    case 1:
                        fmt = File.ReadAllText(_appSettings.PostulantSelectedCampoFe);
                        break;
                    case 2:
                        fmt = File.ReadAllText(_appSettings.PostulantSelectedPrestaFe);
                        break;
                    case 3:
                        fmt = File.ReadAllText(_appSettings.PostulantSelectedFeSalud);
                        break;
                    case 4:
                        fmt = File.ReadAllText(_appSettings.PostulantSelectedGrupoFe);
                        break;
                }
                    
                    fmt = fmt.Replace("[SELECCIONADO]", request.dto.FullNamePostulant);
                    
                    await SendMailEvaluation(request.dto.EmailPostulant, fmt, "!Felicidades! Has sido seleccionado");
              
            }

            

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se notificaron correctamente." }
            };

        }


        private async Task<bool> SendMailEvaluation(string mailuser, string bodyhtml, string campaignname)
        {
            MailRequestDto newMailRequest = new MailRequestDto();
            newMailRequest.From = _appSettings.FromMailNotification;
            newMailRequest.FromName = _appSettings.FromNameNotification;
            newMailRequest.To = new List<string>();
            newMailRequest.To.Add(mailuser);

            newMailRequest.Message = new MessageDto();

            newMailRequest.Message.Subject = campaignname;

            newMailRequest.Message.Body = new BodyDto() { Format = EnumBodyMail.Html, Value = bodyhtml };

            var bmail = await _mailRepository.SendMail(newMailRequest);
            return bmail;

        }

    }
}
