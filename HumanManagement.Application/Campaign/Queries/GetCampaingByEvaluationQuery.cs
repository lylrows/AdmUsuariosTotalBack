using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{

    public class GetCampaingByEvaluationQuery : IRequest<Result>
    {
        
        public class GetCampaingByEvaluationQueryHandler : IRequestHandler<GetCampaingByEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetCampaingByEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetCampaingByEvaluationQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetCampaingByEvaluation();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
