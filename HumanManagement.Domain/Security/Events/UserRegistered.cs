using HumanManagement.Domain.Events;
using HumanManagement.Domain.Security.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Security.Events
{
    public class UserRegistered : IDomainEvent
    {
        public UserMailDto UserMail { get; private set; }
        public UserRegistered(UserMailDto UserMail)
        {
            this.UserMail = UserMail;
        }
    }
}
