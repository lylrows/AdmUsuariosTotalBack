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

namespace HumanManagement.Application.Evaluation.Queries
{
 
    public class GetMyTeamEvaluationQuery : IRequest<Result>
    {
        public MyEvaluationFilter evaluationQueryFilter { get; set; }
        public class GetMyTeamEvaluationQueryHandler : IRequestHandler<GetMyTeamEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetMyTeamEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetMyTeamEvaluationQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetMyTeamEvaluation_Paginated(request.evaluationQueryFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
