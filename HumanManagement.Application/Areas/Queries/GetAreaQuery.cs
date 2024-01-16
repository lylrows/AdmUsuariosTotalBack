using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.Dto;
using HumanManagement.Domain.Areas.QueryFilter;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Queries
{
    public class GetAreaQuery :IRequest<Result>
    {
        public AreasQueryFilter areaQueryFilter { get; set; }
        public class GetAreaQueryHandler : IRequestHandler<GetAreaQuery, Result>
        {
            private readonly IBaseRepository<Domain.Areas.Models.Areas> baseRepository;
            private readonly IAreaRepository areaRepository;
            private IMapper mapper;

            public GetAreaQueryHandler(IBaseRepository<Domain.Areas.Models.Areas> baseRepository,
                                       IMapper mapper,
                                       IAreaRepository areaRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetAreaQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await areaRepository.GetAll(request.areaQueryFilter);
                output.Data = result;
                return output;
            }
        }
    }


}
