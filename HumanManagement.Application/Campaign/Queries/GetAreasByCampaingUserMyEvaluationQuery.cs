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

namespace HumanManagement.Application.Campaign.Queries
{
    public class GetAreasByCampaingUserMyEvaluationQuery : IRequest<Result>
    {
        public AreasByCampaingUserMyEvaluationFilter areasByCampaingUserMyEvaluationFilter { get; set; }
        public class GetAreasByCampaingUserMyEvaluationQueryHandler : IRequestHandler<GetAreasByCampaingUserMyEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetAreasByCampaingUserMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetAreasByCampaingUserMyEvaluationQuery request, CancellationToken cancellationToken)
            {
                var result = await _campaignRepository.GetAreasByCampaingUserMyEvaluation(request.areasByCampaingUserMyEvaluationFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
