using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mail.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Mail.Models
{
    public abstract class MailSender
    {
        protected string textBody;
        protected BodyDto bodyDto;
        protected readonly IHtmlReader htmlReader;
        public MailSender(IHtmlReader htmlReader)
        {
            this.htmlReader = htmlReader;
            textBody = string.Empty;
            bodyDto = new BodyDto();
        }

        public abstract void ReplaceFileBody();
        public void SetTextBodyMail(string pathFile)
        {
            textBody = htmlReader.ReadFromFile(pathFile);
        }
    }
}
