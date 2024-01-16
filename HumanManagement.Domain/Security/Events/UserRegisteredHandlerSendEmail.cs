using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Security.Events
{
    public class UserRegisteredHandlerSendEmail : IEventHandling<UserRegistered>
    {
        private readonly IMailRepository mailRepository;
        private readonly IHtmlReader htmlReader;
        public UserRegisteredHandlerSendEmail(IMailRepository mailRepository, IHtmlReader htmlReader)
        {
            this.mailRepository = mailRepository;
            this.htmlReader = htmlReader;
        }

        public void Handler(UserRegistered args)
        {
            MailSenderUser mailSenderUser = new MailSenderUser(htmlReader, args.UserMail);
            mailRepository.SendMail(mailSenderUser.GetMail());
        }
    }
}
