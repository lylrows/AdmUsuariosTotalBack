using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Mail.Models;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.Domain.Recruitment.Options;

namespace HumanManagement.Domain.Recruitment.Models
{
    public class MailSenderRequest : MailSender
    {
        private RequestMailDto requestMailDto;
        private RequestTemplateHtml requestTemplateHtml;
        private string pathTemplate;
        public MailSenderRequest(IHtmlReader htmlReader, 
                                RequestMailDto requestMailDto,
                                RequestTemplateHtml requestTemplateHtml)
            :base(htmlReader)
        {
            this.requestMailDto = requestMailDto;
            this.requestTemplateHtml = requestTemplateHtml;
            pathTemplate = string.Empty;
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
                    Subject = requestMailDto.Subject
                },
                From = "",
                FromName = "Grupo Fé",
                To =
                {
                    requestMailDto.Email
                },
            };
        }

        public override void ReplaceFileBody()
        {
            SetPathTemplate();
            SetTextBodyMail(pathTemplate);
            string bodyEmail = string.Empty;
            bodyEmail = textBody;
            bodyEmail = bodyEmail.Replace("[FULL_NAME]", requestMailDto.FullName);
            bodyEmail = bodyEmail.Replace("[REQUEST_NUMBER]", requestMailDto.RequestNumber);
            bodyEmail = bodyEmail.Replace("[COMPANY]", requestMailDto.Company);
            bodyEmail = bodyEmail.Replace("[AREA]", requestMailDto.Area);
            bodyEmail = bodyEmail.Replace("[CHARGE]", requestMailDto.Charge);
            bodyEmail = bodyEmail.Replace("[DATE_REGISTER]", requestMailDto.DateRegister.ToString("dd/MM/yyyy"));
            bodyEmail = bodyEmail.Replace("URL_REQUEST", requestMailDto.UrlRequest);
            bodyDto.Format = EnumBodyMail.Html;
            bodyDto.Value = bodyEmail;
        }

        private void SetPathTemplate()
        {
            switch (requestMailDto.TypeMailRequest)
            {
                case Enum.TypeMailRequest.Evaluator:
                    pathTemplate = requestTemplateHtml.RequestToEvaluator;
                    break;
                case Enum.TypeMailRequest.Applicant:
                    pathTemplate = requestTemplateHtml.RequestToApplicant;
                    break;
            }
        }
    }
}
