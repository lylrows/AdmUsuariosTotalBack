using HumanManagement.Application.Response;
using HumanManagement.Domain.Areas.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Queries
{
    public class GetAllAreaQuery : IRequest<Result>
    {
        public class GetAllAreaQueryHandler : IRequestHandler<GetAllAreaQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAllAreaQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetAllAreaQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await areaRepository.GetAreasAll();
                output.Data = result; 
                return output;
            }
        }
    }
}
