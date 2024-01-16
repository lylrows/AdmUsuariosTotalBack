using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetEvaluationQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }

        public class GetEvaluationQueryHandle : IRequestHandler<GetEvaluationQuery, Result>
        {
            private readonly IBaseRepository<EvaluationPostulantsInternalModel> evalutionPostulantBaseRepository;
            private readonly IBaseRepository<EvaluationVacantInternal> evalutionInternalBaseRepository;
            private readonly IEvaluationInternalRepository evaluationInternalRepository;
            private readonly IEvaluationPostulantsInternalRepository evaluationPostulantsInternalRepository;

            public GetEvaluationQueryHandle(IBaseRepository<EvaluationPostulantsInternalModel> evalutionPostulantBaseRepository,
                                            IBaseRepository<EvaluationVacantInternal> evalutionInternalBaseRepository,
                                            IEvaluationInternalRepository evaluationInternalRepository,
                                            IEvaluationPostulantsInternalRepository evaluationPostulantsInternalRepository)
            {
                this.evalutionInternalBaseRepository = evalutionInternalBaseRepository;
                this.evalutionPostulantBaseRepository = evalutionPostulantBaseRepository;
                this.evaluationInternalRepository = evaluationInternalRepository;
                this.evaluationPostulantsInternalRepository = evaluationPostulantsInternalRepository;
            }
            public async Task<Result> Handle(GetEvaluationQuery request, CancellationToken cancellationToken)
            {
                var _existsSelectedPosition = true;
                var evaluation = await evaluationInternalRepository.GetEvaluation(request.IdEvaluation);
                if (evaluation != null)
                {
                    evaluation.postulantDtos = await evaluationPostulantsInternalRepository.GetEvaluationPostulants(request.IdEvaluation);
                    var _selected = evaluation.postulantDtos.Where(x => x.DescripcionState == "Seleccionado").ToList().Count;
                    _existsSelectedPosition = _selected == 0;
                }

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
