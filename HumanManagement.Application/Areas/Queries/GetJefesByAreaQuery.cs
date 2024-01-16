using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace HumanManagement.Application.Areas.Queries
{

    public class GetJefesByAreaQuery : IRequest<Result>
    {
        public JefesQueryFilter jefesQueryFilter { get; set; }

        public class GetJefesByAreaQueryHandler : IRequestHandler<GetJefesByAreaQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetJefesByAreaQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetJefesByAreaQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetJefesByArea(request.jefesQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
