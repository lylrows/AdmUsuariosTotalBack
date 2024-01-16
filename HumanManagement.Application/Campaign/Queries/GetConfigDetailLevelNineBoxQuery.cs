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
    public class GetConfigDetailLevelNineBoxQuery : IRequest<Result>
    {
        public ConfigDetailLevelNineBoxFilter configDetailLevelNineBoxFilter { get; set; }
        public class GetConfigDetailLevelNineBoxQueryHandler : IRequestHandler<GetConfigDetailLevelNineBoxQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetConfigDetailLevelNineBoxQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetConfigDetailLevelNineBoxQuery request, CancellationToken cancellationToken)
            {
                var result = await _campaignRepository.GetConfigDetailLevelNineBoxByCampaign(request.configDetailLevelNineBoxFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
