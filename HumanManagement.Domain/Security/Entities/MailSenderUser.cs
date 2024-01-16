using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Security.Dto;

namespace HumanManagement.Domain.Security.Entities
{
    public class MailSenderUser
    {
        private string textBody;
        private UserMailDto userDto;
        private BodyDto bodyDto;
        private readonly IHtmlReader htmlReader;
        public MailSenderUser(IHtmlReader htmlReader, UserMailDto userDto)
        {
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
                    Classification = "1",
                    Subject = "Usuario Registrado"
                },
                From = "",
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
            bodyEmail = bodyEmail.Replace("USERFULLNAME", userDto.FullName);
            bodyEmail = bodyEmail.Replace("USERNAME", userDto.UserName);
            bodyEmail = bodyEmail.Replace("USERPASSWORD", userDto.Password);
            bodyDto.Format = EnumBodyMail.Html;
            bodyDto.Value = bodyEmail;
        }

        private void SetTextBodyMail()
        {
            textBody = htmlReader.ReadFromFile(Constants.PathTemplateHtml.PATH_TEMPLATE_HTML_MAIL_USER);
        }

    }
}
