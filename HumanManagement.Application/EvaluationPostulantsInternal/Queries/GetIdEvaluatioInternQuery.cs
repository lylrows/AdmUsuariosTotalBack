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
    public class GetIdEvaluatioInternQuery: IRequest<Result>
    {
        public int IdJob { get; set; }

        public class GetIdEvaluatioInternQueryHandle : IRequestHandler<GetIdEvaluatioInternQuery, Result>
        {
            private readonly IBaseRepository<EvaluationVacantInternal> baseRepository;
            public GetIdEvaluatioInternQueryHandle(IBaseRepository<EvaluationVacantInternal> baseRepository)
            {
                this.baseRepository = baseRepository;
            }
            public async Task<Result> Handle(GetIdEvaluatioInternQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.FindPredicate(x => x.IdJob == request.IdJob);

                return new Result
                {
                    Data = entity.Id,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };

            }
        }
    }
}
