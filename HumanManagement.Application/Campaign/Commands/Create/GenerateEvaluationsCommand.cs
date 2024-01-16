using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Commands.Create
{
    public class GenerateEvaluationsCommand : IRequest<Result>
    {
        public int IdCampaign { get; set; }
        public int nIdPerson { get; set; }
    }

    public class GenerateEvaluationsCommandHandler : IRequestHandler<GenerateEvaluationsCommand, Result>
    {
        
        private readonly ICampaignRepository _campaignRepository;
        private readonly AppSettings _appSettings;
        private readonly IMailRepository _mailRepository;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;

        public GenerateEvaluationsCommandHandler(ICampaignRepository campaignRepository, IOptions<AppSettings> appSettings
            , IMailRepository mailRepository, IEvaluationRepository evaluationRepository, IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify)
        {
            _baseNotification = basenotify;
            this._campaignRepository = campaignRepository;
            _appSettings = appSettings.Value;
            this._mailRepository = mailRepository;
            this._evaluationRepository = evaluationRepository;
        }

        public async Task<Result> Handle(GenerateEvaluationsCommand request, CancellationToken cancellationToken)
        {

            var entity = await _campaignRepository.GenerateEvaluations(request.IdCampaign);

            if (entity == 0)
            {
                return new Result
                {
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                    MessageError = new List<string>() { "No se pudieron generar las evaluaciones." }

                };
            }

           
            return new Result
            {
                StateCode =  Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se generaron las evaluaciones de manera correcta." }

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
