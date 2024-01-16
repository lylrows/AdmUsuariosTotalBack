using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetEvaluationRatingQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public class GetEvaluationRatingQueryHandler : IRequestHandler<GetEvaluationRatingQuery, Result>
        {
            private readonly IEvaluationRatingRepository evaluationRatingRepository;
            public GetEvaluationRatingQueryHandler(IEvaluationRatingRepository evaluationRatingRepository)
            {
                this.evaluationRatingRepository = evaluationRatingRepository;
            }
            public async Task<Result> Handle(GetEvaluationRatingQuery request, CancellationToken cancellationToken)
            {
                var dto = await evaluationRatingRepository.GetEvaluationRatingPostulants(request.IdEvaluation, request.IdPostulant);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
