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
    public class GetGerenciasByUserEvaluationQuery : IRequest<Result>
    {
        
        public AreasComboQueryFilter areasComboQueryFilter { get; set; }

        public class GetGerenciasByUserEvaluationQueryHandler : IRequestHandler<GetGerenciasByUserEvaluationQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetGerenciasByUserEvaluationQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetGerenciasByUserEvaluationQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetGerenciasByUserEvaluation(request.areasComboQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
