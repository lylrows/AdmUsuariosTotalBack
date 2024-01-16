using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Postulant.Security.Dto;
using Microsoft.Extensions.Options;
using System.IO;

namespace HumanManagement.Domain.Postulant.Security.Entities
{
    public class MailSenderUser
    {
        private string textBody;
        private UserMailDto userDto;
        private BodyDto bodyDto;
        private readonly IHtmlReader htmlReader;
        private readonly string template;
        private readonly string url;
        public MailSenderUser(IHtmlReader htmlReader, UserMailDto userDto, string template, string url)
        {
            this.url = url;
            this.template = template;
            this.userDto = userDto;
            this.htmlReader = htmlReader;
            bodyDto = new BodyDto();
            SetTextBodyMail();
        }

        public MailRequestDto GetMail()
        {
            ReplaceFileBody();
            return new MailRequestDto
            {
                Message = new MessageDto
                {
                    Body = bodyDto,
                    Classification = null,
                    Subject = "Activación de cuenta"
                },
                From = "junior.espinoza@efitec.pe",
                FromName = "Grupo Fé",
                To =
                {
                    userDto.Email
                },
            };
        }
        public MailRequestDto GetMailPostulantConfirmation(string job)
        {
            ReplaceFileBodyJob(job);
            return new MailRequestDto
            {
                Message = new MessageDto
                {
                    Body = bodyDto,
                    Classification = null,
                    Subject = "Confirmación de postulación"
                },
                From = "junior.espinoza@efitec.pe",
                FromName = "Grupo Fé",
                To =
                {
                    userDto.Email
                },
            };
        }

        private void ReplaceFileBody()
        {
            string bodyEmail = string.Empty;
            bodyEmail = textBody;
            bodyEmail = bodyEmail.Replace("[USER]", userDto.FullName);
            bodyEmail = bodyEmail.Replace("[URLPASSWORD]", url + "/" + userDto.Id);
            bodyDto.Format = EnumBodyMail.Html;
            bodyDto.Value = bodyEmail;
        }
        private void ReplaceFileBodyJob(string job)
        {
            string bodyEmail = string.Empty;
            bodyEmail = textBody;
            bodyEmail = bodyEmail.Replace("[USER]", userDto.FullName);
            bodyEmail = bodyEmail.Replace("[URLPASSWORD]", url + "/" + userDto.Id);
            bodyEmail = bodyEmail.Replace("[JOB]", job);
            bodyDto.Format = EnumBodyMail.Html;
            bodyDto.Value = bodyEmail;
        }

        private void SetTextBodyMail()
        {
            textBody = File.ReadAllText(template);
        }

    }
}
