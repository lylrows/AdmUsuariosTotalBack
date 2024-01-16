using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetEvaluationPostulantLogrosQuery: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }

        public class GetEvaluationPostulantLogrosQueryHandle : IRequestHandler<GetEvaluationPostulantLogrosQuery, Result>
        {
            private readonly IBaseRepository<EvaluationPostulantInternalLogros> baseRepository;
            public GetEvaluationPostulantLogrosQueryHandle(IBaseRepository<EvaluationPostulantInternalLogros> baseRepository)
            {
                this.baseRepository = baseRepository;
            }
            public async Task<Result> Handle(GetEvaluationPostulantLogrosQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.FindPredicate(x => x.IdEvaluationPostulant == request.IdEvaluationPostulant);

                return new Result
                {
                    Data = entity,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
