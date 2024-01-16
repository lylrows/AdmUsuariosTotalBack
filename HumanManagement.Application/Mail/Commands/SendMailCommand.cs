using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Mail.Commands
{

    public class SendMailCommand : IRequest<bool>
    {
        public MailRequestDto mailRequest { get; set; }
    }

    public class SendMailCommandHandler : IRequestHandler<SendMailCommand, bool>
    {

        private readonly IMailRepository _mailRepository;
     

        public SendMailCommandHandler(IMailRepository mailRepository)
        {
            this._mailRepository= mailRepository;
        }
        
        public async Task<bool> Handle(SendMailCommand request, CancellationToken cancellationToken)
        {
            var resultPagination = await _mailRepository.SendMail( request.mailRequest);
            return resultPagination;
        }
    }

}
