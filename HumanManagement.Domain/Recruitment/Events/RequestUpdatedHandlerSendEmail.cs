using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Models;
using HumanManagement.Domain.Recruitment.Options;
using Microsoft.Extensions.Options;

namespace HumanManagement.Domain.Recruitment.Events
{
    public class RequestUpdatedHandlerSendEmail : IEventHandling<RequestUpdated>
    {
        private readonly IMailRepository mailRepository;
        private readonly IRequestMailRepository requestMailRepository;
        private readonly IHtmlReader htmlReader;
        private readonly RequestTemplateHtml requestTemplateHtml;
        public RequestUpdatedHandlerSendEmail(IMailRepository mailRepository,
                                              IHtmlReader htmlReader,
                                              IRequestMailRepository requestMailRepository,
                                              IOptions<RequestTemplateHtml> requestTemplateHtml)
        {
            this.mailRepository = mailRepository;
            this.htmlReader = htmlReader;
            this.requestMailRepository = requestMailRepository;
            this.requestTemplateHtml = requestTemplateHtml.Value;
        }
        public async void Handler(RequestUpdated args)
        {
            var requestReponseMailDto = await requestMailRepository.GetResponseMailById(args.IdRequestFlow);
            requestReponseMailDto.SetTypeMailRequest();
            requestReponseMailDto.SetUrlRequest(requestTemplateHtml.UrlRequest);
            requestReponseMailDto.SetUrlRequestNew(requestTemplateHtml.UrlRequestNew);
            MailSenderResponse mailSenderResponse = new MailSenderResponse(htmlReader, requestReponseMailDto, requestTemplateHtml);
            await mailRepository.SendMail(mailSenderResponse.GetMail());
        }
    }
}
