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

    public class GetConfigLevelNineBoxQuery : IRequest<Result>
    {
        
        public class GetConfigLevelNineBoxQueryHandler : IRequestHandler<GetConfigLevelNineBoxQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetConfigLevelNineBoxQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetConfigLevelNineBoxQuery request, CancellationToken cancellationToken)
            {
                var result = await _campaignRepository.GetConfigLevelNineBox();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
