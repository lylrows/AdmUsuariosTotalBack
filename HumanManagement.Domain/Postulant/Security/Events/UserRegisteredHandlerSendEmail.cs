using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Postulant.Security.Entities;
using HumanManagement.Domain.Security.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Events
{
    public class UserRegisteredHandlerSendEmail : IEventHandling<UserRegistered>
    {
        private readonly IMailRepository mailRepository;
        private readonly IHtmlReader htmlReader;
        private readonly AppSettings _appSettings;
        public UserRegisteredHandlerSendEmail(IMailRepository mailRepository, IHtmlReader htmlReader, IOptions<AppSettings> appSettings)
        {
            this.mailRepository = mailRepository;
            this.htmlReader = htmlReader;
            this._appSettings = appSettings.Value;
        }

        public void Handler(UserRegistered args)
        {
            MailSenderUser mailSenderUser = new MailSenderUser(htmlReader, args.UserMail, _appSettings.ActivateAccountTemplateHtml, _appSettings.HomeUrl);
            mailRepository.SendMail(mailSenderUser.GetMail());
        }
    }
}
