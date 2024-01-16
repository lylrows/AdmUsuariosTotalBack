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
    public class GetSubAreasByAreaQuery : IRequest<Result>
    {
        public SubAreasComboQueryFilter subAreasComboQueryFilter { get; set; }

        public class GetAreaByCompanyQueryHandler : IRequestHandler<GetSubAreasByAreaQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreaByCompanyQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetSubAreasByAreaQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetSubAreasByArea(request.subAreasComboQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
