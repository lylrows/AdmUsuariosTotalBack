using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{
    public class GetListEvaluationPaginationQuery : IRequest<Result>
    {
        public EvaluationQueryFilterDto evaluationQueryFilter { get; set; }
        public int active { get; set; }
        public class GetListEvaluationPaginationQueryHandler : IRequestHandler<GetListEvaluationPaginationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetListEvaluationPaginationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetListEvaluationPaginationQuery request, CancellationToken cancellationToken)
            {
                if(request.active == 0)
                {
                    var resultPagination = await _campaignRepository.GetListEvaluationsPaginationDeleted(request.evaluationQueryFilter);
                    return new Result
                    {
                        StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                        Data = resultPagination
                    };
                }
                else
                {
                    var resultPagination = await _campaignRepository.GetListEvaluationsPagination(request.evaluationQueryFilter);
                    return new Result
                    {
                        StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                        Data = resultPagination
                    };
                }
            }
        }
    }
}
