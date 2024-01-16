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
    public class GetListEvaluationPostulantQuery: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
        public class GetListEvaluationPostulantQueryHandler : IRequestHandler<GetListEvaluationPostulantQuery, Result>
        {
            private readonly IEvaluationRepository evaluationRepository;
            private readonly IEvaluationPostulantRepository evaluationPostulantRepository;
            public GetListEvaluationPostulantQueryHandler(IEvaluationRepository evaluationRepository,
                                                      IEvaluationPostulantRepository evaluationPostulantRepository)
            {
                this.evaluationRepository = evaluationRepository;
                this.evaluationPostulantRepository = evaluationPostulantRepository;
            }
            public async Task<Result> Handle(GetListEvaluationPostulantQuery request, CancellationToken cancellationToken)
            {
                var listEvaluation= await evaluationPostulantRepository.GetEvaluationPostulantsExport(request.IdEvaluation);
                return new Result
                {
                    Data = listEvaluation,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }


    }
}
