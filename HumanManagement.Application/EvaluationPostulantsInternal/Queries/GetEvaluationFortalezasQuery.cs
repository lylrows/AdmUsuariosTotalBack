using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetEvaluationFortalezasQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }

        public class GetEvaluationFortalezasQueryHandle : IRequestHandler<GetEvaluationFortalezasQuery, Result>
        {
            private readonly IEvaluationFortalezasInternRepository evaluationFortalezasRepository;

            public GetEvaluationFortalezasQueryHandle(IEvaluationFortalezasInternRepository evaluationFortalezasRepository)
            {
                this.evaluationFortalezasRepository = evaluationFortalezasRepository;
            }
            public async Task<Result> Handle(GetEvaluationFortalezasQuery request, CancellationToken cancellationToken)
            {
                var dto = await evaluationFortalezasRepository.GetEvaluationFortalezasPostulants(request.IdEvaluation, request.IdPostulant);
                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
