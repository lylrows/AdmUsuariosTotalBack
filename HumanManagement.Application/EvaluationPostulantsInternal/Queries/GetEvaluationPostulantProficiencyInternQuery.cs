using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetEvaluationPostulantProficiencyInternQuery: IRequest<Result> 
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public int Flag { get; set; }

        public class GetEvaluationPostulantProficiencyInternQueryHandle : IRequestHandler<GetEvaluationPostulantProficiencyInternQuery, Result>
        {
            private readonly IEvaluationProficiencyInternRepository evaluationProficiencyRepository;
            public GetEvaluationPostulantProficiencyInternQueryHandle(IEvaluationProficiencyInternRepository evaluationProficiencyRepository)
            {
                this.evaluationProficiencyRepository = evaluationProficiencyRepository;
            }
            public async Task<Result> Handle(GetEvaluationPostulantProficiencyInternQuery request, CancellationToken cancellationToken)
            {
                var dto = await evaluationProficiencyRepository.GetEvaluationProficiencies(request.IdEvaluation, request.IdPostulant, request.Flag);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
