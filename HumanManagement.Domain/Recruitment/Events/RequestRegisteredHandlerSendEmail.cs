using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Enum;
using HumanManagement.Domain.Recruitment.Models;
using HumanManagement.Domain.Recruitment.Options;
using Microsoft.Extensions.Options;

namespace HumanManagement.Domain.Recruitment.Events
{
    public class RequestRegisteredHandlerSendEmail : IEventHandling<RequestRegistered>
    {
        private readonly IMailRepository mailRepository;
        private readonly IHtmlReader htmlReader;
        private readonly IRequestMailRepository requestMailRepository;
        private readonly RequestTemplateHtml requestTemplateHtml;
        public RequestRegisteredHandlerSendEmail(IMailRepository mailRepository,
                                                IHtmlReader htmlReader,
                                                IRequestMailRepository requestMailRepository,
                                                IOptions<RequestTemplateHtml> requestTemplateHtml)
        {
            this.mailRepository = mailRepository;
            this.htmlReader = htmlReader;
            this.requestMailRepository = requestMailRepository;
            this.requestTemplateHtml = requestTemplateHtml.Value;
        }
        public async void Handler(RequestRegistered args)
        {
            var requestMailDto = await requestMailRepository.GetRequestToSendMailToApplicantById(args.IdReuqest);
            requestMailDto.SetTypeMailRequest(TypeMailRequest.Applicant);
            var requestSendMailToEvaluatorDto = await requestMailRepository.GetRequestToSendMailToEvaluatorById(args.IdReuqest);
            requestSendMailToEvaluatorDto.SetTypeMailRequest(TypeMailRequest.Evaluator);
            requestMailDto.SetUrlRequest(requestTemplateHtml.UrlRequest);
            MailSenderRequest mailSenderRequestToApplicant = new MailSenderRequest(htmlReader, requestMailDto, requestTemplateHtml);
            await mailRepository.SendMail(mailSenderRequestToApplicant.GetMail());
            requestSendMailToEvaluatorDto.SetUrlRequest(requestTemplateHtml.UrlRequest);
            MailSenderRequest mailSenderRequestToEvaluator = new MailSenderRequest(htmlReader, requestSendMailToEvaluatorDto, requestTemplateHtml);
            await mailRepository.SendMail(mailSenderRequestToEvaluator.GetMail());
        }
    }
}
