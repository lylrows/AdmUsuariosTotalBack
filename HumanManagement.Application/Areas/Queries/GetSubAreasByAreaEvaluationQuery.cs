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
    public class GetSubAreasByAreaEvaluationQuery : IRequest<Result>
    {
        public SubAreasEvaluationComboQueryFilter subAreasEvaluationComboQueryFilter { get; set; }

        public class GetSubAreasByAreaEvaluationQueryHandler : IRequestHandler<GetSubAreasByAreaEvaluationQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetSubAreasByAreaEvaluationQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetSubAreasByAreaEvaluationQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetSubAreasByAreaEvaluation(request.subAreasEvaluationComboQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
