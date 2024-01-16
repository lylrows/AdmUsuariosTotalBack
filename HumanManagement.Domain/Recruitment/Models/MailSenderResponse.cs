using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Mail.Models;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.Domain.Recruitment.Options;

namespace HumanManagement.Domain.Recruitment.Models
{
    public class MailSenderResponse: MailSender
    {
        private ResponseMailDto responseMail;
        private RequestTemplateHtml requestTemplateHtml;
        private string pathTemplate;
        public MailSenderResponse(IHtmlReader htmlReader, 
                                    ResponseMailDto responseMail,
                                    RequestTemplateHtml requestTemplateHtml)
            :base(htmlReader)
        {
            this.responseMail = responseMail;
            this.requestTemplateHtml = requestTemplateHtml;
        }

        public MailRequestDto GetMail()
        {
            ReplaceFileBody();
            return new MailRequestDto
            {
                Message = new MessageDto
                {
                    Body = bodyDto,
                    Classification = "1",
                    Subject = responseMail.Subject
                },
                From = "",
                FromName = "Grupo Fé",
                To =
                {
                    responseMail.Email
                },
            };
        }

        public override void ReplaceFileBody()
        {
            SetPathTemplate();
            SetTextBodyMail(pathTemplate);
            string bodyEmail = string.Empty;
            bodyEmail = textBody;
            bodyEmail = bodyEmail.Replace("[FULL_NAME]", responseMail.FullName);
            bodyEmail = bodyEmail.Replace("[REQUEST_NUMBER]", responseMail.RequestNumber);
            bodyEmail = bodyEmail.Replace("[COMMENT]", responseMail.Comment);
            bodyEmail = bodyEmail.Replace("URL_REQUEST", responseMail.UrlRequest);
            bodyEmail = bodyEmail.Replace("URL_REQUEST_NEW", responseMail.UrlRequestNew);
            bodyDto.Format = EnumBodyMail.Html;
            bodyDto.Value = bodyEmail;
        }

        private void SetPathTemplate()
        {
            switch (responseMail.TypeMailRequest)
            {
                case Enum.TypeMailRequest.ResponseAccepted:
                    pathTemplate = requestTemplateHtml.RequestAccepted;
                    break;
                case Enum.TypeMailRequest.ResponseRejected:
                    textBody = requestTemplateHtml.RequestRejected;
                    break;
            }
        }
    }
}
