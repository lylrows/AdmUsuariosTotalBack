using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.Domain.Recruitment.QueryFilter;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recruitment.Queries
{
    public class GetRequestFlowQuery : IRequest<IEnumerable<ListRequestFlowDto>>
    {
        public int requestDto { get; set; }
        public class GetRequestFlowHandler : IRequestHandler<GetRequestFlowQuery, IEnumerable<ListRequestFlowDto>>
        {
            private readonly IRequestRepository requestRepository;
            private IMapper mapper;

            public GetRequestFlowHandler(IMapper mapper,
                                       IRequestRepository requestRepository)
            {
                this.mapper = mapper;
                this.requestRepository = requestRepository;
            }
            public async Task<IEnumerable<ListRequestFlowDto>> Handle(GetRequestFlowQuery request, CancellationToken cancellationToken)
            {
                var result = await requestRepository.GetRequestFlow(request.requestDto);
                return result;
            }
        }
    }
}
