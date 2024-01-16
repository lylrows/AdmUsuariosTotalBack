using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Update
{
  
    public class RequestDocumentObserverCommand : IRequest<Result>
    {
        public int IdDocument { get; set; }
    }
    public class RequestDocumentObserverCommandHandler : IRequestHandler<RequestDocumentObserverCommand, Result>
    {
        
        private readonly IRequestMedicalRepository requestMedicalRepository;
        public RequestDocumentObserverCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this.requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(RequestDocumentObserverCommand request, CancellationToken cancellationToken)
        {

            await requestMedicalRepository.RequestDocumentObserve(request.IdDocument,"");

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
