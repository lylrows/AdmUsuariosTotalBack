using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HumanManagement.Application.Recruitment.Queries
{
    public class AddRequestFlowQuery : IRequest<int>
    {
        public RequestFlowDto requestDto { get; set; }
        public class AddRequestFlowQueryHandler : IRequestHandler<AddRequestFlowQuery, int>
        {
            private readonly IRequestRepository requestRepository;

            public AddRequestFlowQueryHandler(IRequestRepository requestRepository)
            {
                
                this.requestRepository = requestRepository;
            }
            public async Task<int> Handle(AddRequestFlowQuery request, CancellationToken cancellationToken)
            {
                var output = await requestRepository.AddRequestFlow(request.requestDto);

                return output;
            }
        }
    }
}
