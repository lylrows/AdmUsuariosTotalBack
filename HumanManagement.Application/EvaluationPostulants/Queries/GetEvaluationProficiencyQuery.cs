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
    public class GetEvaluationProficiencyQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public class GetEvaluationProficiencyQueryHandler : IRequestHandler<GetEvaluationProficiencyQuery, Result>
        {
            private readonly IEvaluationProficiencyRepository evaluationProficiencyRepository;
            public GetEvaluationProficiencyQueryHandler(IEvaluationProficiencyRepository evaluationProficiencyRepository)
            {
                this.evaluationProficiencyRepository = evaluationProficiencyRepository;
            }
            public async Task<Result> Handle(GetEvaluationProficiencyQuery request, CancellationToken cancellationToken)
            {
                var dto = await evaluationProficiencyRepository.GetEvaluationProficiencies(request.IdEvaluation, request.IdPostulant);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = dto
                };
            }
        }
    }
}
