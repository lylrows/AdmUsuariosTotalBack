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
    public class GetEvaluationPostulantCurriculumQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }

        public class GetEvaluationPostulantCurriculumQueryHandle : IRequestHandler<GetEvaluationPostulantCurriculumQuery, Result>
        {
            private readonly IEvaluationPostulantInfoCurriculumRepository evaluationPostulantInfoCurriculumRepository;
            public GetEvaluationPostulantCurriculumQueryHandle(IEvaluationPostulantInfoCurriculumRepository evaluationPostulantInfoCurriculumRepository)
            {
                this.evaluationPostulantInfoCurriculumRepository = evaluationPostulantInfoCurriculumRepository;
            }
            public async Task<Result> Handle(GetEvaluationPostulantCurriculumQuery request, CancellationToken cancellationToken)
            {
                var dto = await evaluationPostulantInfoCurriculumRepository.GetList(request.IdEvaluation);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
