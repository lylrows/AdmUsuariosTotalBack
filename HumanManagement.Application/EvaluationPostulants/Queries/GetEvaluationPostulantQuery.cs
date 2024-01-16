using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetEvaluationPostulantQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public class GetEvaluationPostulantQueryHandler : IRequestHandler<GetEvaluationPostulantQuery, Result>
        {
            private readonly IEvaluationRepository evaluationRepository;
            private readonly IEvaluationPostulantRepository evaluationPostulantRepository;
            public GetEvaluationPostulantQueryHandler(IEvaluationRepository evaluationRepository,
                                                      IEvaluationPostulantRepository evaluationPostulantRepository)
            {
                this.evaluationRepository = evaluationRepository;
                this.evaluationPostulantRepository = evaluationPostulantRepository;
            }
            public async Task<Result> Handle(GetEvaluationPostulantQuery request, CancellationToken cancellationToken)
            {
                var _existsSelectedPosition = true;
                var evaluation = await evaluationRepository.GetEvaluation(request.IdEvaluation);
                evaluation.postulantDtos = await evaluationPostulantRepository.GetEvaluationPostulants(request.IdEvaluation);
                var _selected = evaluation.postulantDtos.Where(x => x.DescripcionState == "Seleccionado").ToList().Count;
                _existsSelectedPosition = _selected == 0;

                return new Result
                {
                    Data = evaluation,
                    DataDetail = _existsSelectedPosition,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
