using HumanManagement.Domain.Mail.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Mail.Contracts
{
    public interface IMailRepository
    {
        Task<bool> SendMail(MailRequestDto mailRequest);
    }
}
