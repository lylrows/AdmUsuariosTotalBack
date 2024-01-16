using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.Domain.EvaluationPostulant.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetEvaluationListQuery: IRequest<Result> 
    {
        public EvaluationQueryFilter Filter { get; set; }
        public class GetEvaluationListQueryHandle : IRequestHandler<GetEvaluationListQuery, Result>
        {
            private readonly IEvaluationRepository evaluationRepository;
            public GetEvaluationListQueryHandle(IEvaluationRepository evaluationRepository)
            {
                this.evaluationRepository = evaluationRepository;
            }
            public async Task<Result> Handle(GetEvaluationListQuery request, CancellationToken cancellationToken)
            {
              var dto = await evaluationRepository.GetEvaluationList(request.Filter.IdJob);
              dto = dto.Skip((request.Filter.pagination.CurrentPage - 1) * 10).Take(10).ToList();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = new
                    {
                        List = dto,
                        TotalItems= dto.Count(),
                        TotalPages= 1
                    }
                };
            }
        }
    }
}
