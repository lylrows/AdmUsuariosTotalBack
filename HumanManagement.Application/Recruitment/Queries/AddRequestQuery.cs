using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HumanManagement.Application.Recruitment.Queries
{
    public class AddRequestQuery : IRequest<int>
    {
        public RequestDto requestDto { get; set; }
        public class AddRequestQueryHandler : IRequestHandler<AddRequestQuery, int>
        {
            
            private readonly IRequestRepository requestRepository;
            

            public AddRequestQueryHandler(IRequestRepository requestRepository)
            {

                this.requestRepository = requestRepository;
            }
            public async Task<int> Handle(AddRequestQuery request, CancellationToken cancellationToken)
            {
                var output = await requestRepository.AddRequest(request.requestDto);
                return output;
            }
        }
    }
}
