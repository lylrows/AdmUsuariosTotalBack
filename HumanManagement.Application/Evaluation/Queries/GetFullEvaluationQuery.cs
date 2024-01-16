using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.Domain.Evaluation.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Evaluation.Queries
{
    public class GetFullEvaluationQuery : IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public class GetFullEvaluationQueryHandler : IRequestHandler<GetFullEvaluationQuery, Result>
        {
            private readonly IEvaluationRepository _evaluationRepository;
            public GetFullEvaluationQueryHandler(IEvaluationRepository evaluationRepository)
            {
                this._evaluationRepository= evaluationRepository;
            }


            public async Task<Result> Handle(GetFullEvaluationQuery request, CancellationToken cancellationToken)
            {
                var header = await _evaluationRepository.GetEvaluationById(request.IdEvaluation);

                FullEvaluationDto evaluation = new FullEvaluationDto();
                if (header != null)
                {
                    evaluation.header = header;


                    var details = await _evaluationRepository.GetListEvaluationDetail(request.IdEvaluation);
                    evaluation.details = details;
                }


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = evaluation
                };
            }
        }
    }
}
