using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using MediatR;

using System.Threading;
using System.Threading.Tasks;


namespace HumanManagement.Application.Recruitment.Queries
{
    public class UpdateRequestPreQuery : IRequest<int>
    {
        public RequestDto requestDto { get; set; }
        public class UpdateRequestPreQueryHandler : IRequestHandler<UpdateRequestPreQuery, int>
        {
            private readonly IRequestRepository requestRepository;
            
            public UpdateRequestPreQueryHandler(IRequestRepository requestRepository)
            {
                this.requestRepository = requestRepository;
            }
            public async Task<int> Handle(UpdateRequestPreQuery request, CancellationToken cancellationToken)
            {
                var output = await requestRepository.UpdateRequestPre(request.requestDto);
                return output;
            }
        }
    }
}
