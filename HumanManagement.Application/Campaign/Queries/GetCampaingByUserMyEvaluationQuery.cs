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
    public class GetCampaingByUserMyEvaluationQuery : IRequest<Result>
    {
        public CampaingByUserMyEvaluationFilter campaingByUserMyEvaluationFilter { get; set; }
        public class GetCampaingByUserMyEvaluationQueryHandler : IRequestHandler<GetCampaingByUserMyEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetCampaingByUserMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetCampaingByUserMyEvaluationQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetCampaingByUserMyEvaluation(request.campaingByUserMyEvaluationFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }

}
