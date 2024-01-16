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
   
    public class GetPrintEvaluationQuery : IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public class GetPrintEvaluationQueryHandler : IRequestHandler<GetPrintEvaluationQuery, Result>
        {
            private readonly IEvaluationRepository _evaluationRepository;
            public GetPrintEvaluationQueryHandler(IEvaluationRepository evaluationRepository)
            {
                this._evaluationRepository = evaluationRepository;
            }


            public async Task<Result> Handle(GetPrintEvaluationQuery request, CancellationToken cancellationToken)
            {
                var header = await _evaluationRepository.GetPrintEvaluationById(request.IdEvaluation);

                PrintEvaluationDto evaluation = new PrintEvaluationDto();
                if (header != null)
                {
                    evaluation.header = header;


                    var objetives = await _evaluationRepository.GetListEvaluationDetailObjetivos(request.IdEvaluation);
                    evaluation.objetives = objetives;

                    var competencies = await _evaluationRepository.GetListEvaluationDetailCompetencias(request.IdEvaluation);
                    evaluation.competencies = competencies;

                    var comments = await _evaluationRepository.GetListEvaluationDetailComentarios(request.IdEvaluation);
                    evaluation.comments = comments;

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
