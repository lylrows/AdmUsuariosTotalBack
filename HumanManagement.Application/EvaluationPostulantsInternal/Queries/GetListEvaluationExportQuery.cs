using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{

    public class GetListEvaluationExportQuery : IRequest<Result>
    {
        public int IdEvaluation { get; set; }

        public class GetListEvaluationExportQueryHandle : IRequestHandler<GetListEvaluationExportQuery, Result>
        {
            private readonly IEvaluationPostulantsInternalRepository evaluationPostulantsInternalRepository;

            public GetListEvaluationExportQueryHandle(
            IEvaluationPostulantsInternalRepository evaluationPostulantsInternalRepository)
            {
                this.evaluationPostulantsInternalRepository = evaluationPostulantsInternalRepository;
            }
            public async Task<Result> Handle(GetListEvaluationExportQuery request, CancellationToken cancellationToken)
            {
                var listpostulantDtos = await evaluationPostulantsInternalRepository.GetEvaluationPostulantsExport(request.IdEvaluation);
               
                return new Result
                {
                    Data = listpostulantDtos,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
