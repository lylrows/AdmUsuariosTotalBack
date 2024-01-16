using AutoMapper;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recruitment.Queries
{
    public class UpdateRequestQuery : IRequest<int>
    {
        public RequestUpdatedDto requestDto { get; set; }
        public class UpdateRequestQueryHandler : IRequestHandler<UpdateRequestQuery, int>
        {
            private readonly IRequestRepository requestRepository;
            private IMapper mapper;

            public UpdateRequestQueryHandler(IMapper mapper,
                                       IRequestRepository requestRepository)
            {
                this.mapper = mapper;
                this.requestRepository = requestRepository;
            }
            public async Task<int> Handle(UpdateRequestQuery request, CancellationToken cancellationToken)
            {
                var output = await requestRepository.UpdateRequest(request.requestDto);

                return output;
            }
        }
    }
}
