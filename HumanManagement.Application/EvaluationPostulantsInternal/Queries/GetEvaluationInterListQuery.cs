using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetEvaluationInterListQuery: IRequest<Result>
    {
        public EvaluationInternQueryFilter Filter { get; set; }

        public class GetEvaluationInterListQueryHandle : IRequestHandler<GetEvaluationInterListQuery, Result>
        {
            private readonly IEvaluationInternalRepository evaluationInternalRepository;

            public GetEvaluationInterListQueryHandle(IEvaluationInternalRepository evaluationInternalRepository)
            {
                this.evaluationInternalRepository = evaluationInternalRepository;
            }
            public async Task<Result> Handle(GetEvaluationInterListQuery request, CancellationToken cancellationToken)
            {
                var dto = await evaluationInternalRepository.GetEvaluationList(request.Filter.IdJob);
                dto = dto.Skip((request.Filter.pagination.CurrentPage - 1) * 10).Take(10).ToList();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = new
                    {
                        List = dto,
                        TotalItems = dto.Count(),
                        TotalPages = 1
                    }
                };
            }
        }
    }
}
