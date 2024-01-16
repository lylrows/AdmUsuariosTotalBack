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
    public class GetRequestQuery : IRequest<Result>
    {
        public RequestQueryFilter requestQueryFilter { get; set; }
        public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, Result>
        {
            private readonly IBaseRepository<Domain.Home.Models.Document> baseRepository;
            private readonly IRequestRepository requestRepository;
            private IMapper mapper;

            public GetRequestQueryHandler(IBaseRepository<Domain.Home.Models.Document> baseRepository,
                                       IMapper mapper,
                                       IRequestRepository requestRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.requestRepository = requestRepository;
            }
            public async Task<Result> Handle(GetRequestQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await requestRepository.GetListRequestPagination(request.requestQueryFilter);
                output.Data = result;
                return output;
            }
        }

    }
}
