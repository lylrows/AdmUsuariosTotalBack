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
    public class GetSubAreasByCampaingUserMyEvaluationQuery : IRequest<Result>
    {
        public SubAreasByCampaingUserMyEvaluationFilter subAreasByCampaingUserMyEvaluationFilter { get; set; }
        public class GetSubAreasByCampaingUserMyEvaluationQueryHandler : IRequestHandler<GetSubAreasByCampaingUserMyEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetSubAreasByCampaingUserMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetSubAreasByCampaingUserMyEvaluationQuery request, CancellationToken cancellationToken)
            {
                var result = await _campaignRepository.GetSubAreasByCampaingUserMyEvaluation(request.subAreasByCampaingUserMyEvaluationFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}