using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Home.Contracts;
using HumanManagement.Domain.Home.Dto;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Home.Queries
{
    
    public class GetOrganizationQuery : IRequest<Result>
    {
        public OrganizationQueryFilter organizationQueryFilter { get; set; }
        public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, Result>
        {
            private readonly IBaseRepository<Domain.Home.Models.Organization> baseRepository;
            private readonly IOrganizationRepository organizationRepository;
            private IMapper mapper;

            public GetOrganizationQueryHandler(IBaseRepository<Domain.Home.Models.Organization> baseRepository,
                                               IMapper mapper,
                                               IOrganizationRepository organizationRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.organizationRepository = organizationRepository;
;
            }
            public async Task<Result> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await organizationRepository.GetListOrganizationPagination(request.organizationQueryFilter);
                output.Data = result;
                return output;
            }
        }
    }
}
