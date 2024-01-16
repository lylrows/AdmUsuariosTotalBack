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
    public class GetAreasByGerenciaEvaluationQuery : IRequest<Result>
    {
        public AreasEvaluationComboQueryFilter areasEvaluationComboQueryFilter { get; set; }

        public class GetAreasByGerenciaEvaluationQueryHandler : IRequestHandler<GetAreasByGerenciaEvaluationQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreasByGerenciaEvaluationQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetAreasByGerenciaEvaluationQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetAreasByGerenciaEvaluation(request.areasEvaluationComboQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
