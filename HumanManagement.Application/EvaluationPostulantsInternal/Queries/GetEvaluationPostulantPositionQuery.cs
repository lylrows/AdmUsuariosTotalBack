using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetEvaluationPostulantPositionQuery: IRequest<Result> 
    {
        public int IdEvaluation { get; set; }

        public class GetEvaluationPostulantPositionQueryHandle : IRequestHandler<GetEvaluationPostulantPositionQuery, Result>
        {
            private readonly IBaseRepository<EvaluationPostulantPosition> baseRepository;
            private readonly IEvaluationInternalRepository evaluationInternalRepository;
            public GetEvaluationPostulantPositionQueryHandle(IBaseRepository<EvaluationPostulantPosition> baseRepository,
                IEvaluationInternalRepository evaluationInternalRepository)
            {
                this.baseRepository = baseRepository;
                this.evaluationInternalRepository = evaluationInternalRepository;
            }
            public async Task<Result> Handle(GetEvaluationPostulantPositionQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.FindPredicate(x => x.IdEvaluationPostulant == request.IdEvaluation);

                var _positions = await evaluationInternalRepository.GetPositionPostulant(request.IdEvaluation);

                return new Result
                {
                    Data = entity,
                    DataDetail = _positions,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
