using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Evaluation.Queries
{
    public class GetMyEvaluationQuery : IRequest<Result>
    {
        public MyEvaluationFilter evaluationQueryFilter { get; set; }
        public class GetMyEvaluationQueryHandler : IRequestHandler<GetMyEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetMyEvaluationQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetMyEvaluation_Paginated(request.evaluationQueryFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
