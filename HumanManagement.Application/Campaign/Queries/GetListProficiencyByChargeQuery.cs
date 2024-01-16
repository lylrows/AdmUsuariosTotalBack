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
    public class GetListProficiencyByChargeQuery : IRequest<Result>
    {
        public ProficiencyByChargeFilterDto proficiencyQueryFilter { get; set; }
        public class GetListProficiencyByChargeQueryHandler : IRequestHandler<GetListProficiencyByChargeQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetListProficiencyByChargeQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }

            public async Task<Result> Handle(GetListProficiencyByChargeQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetProficiencyByCharge(request.proficiencyQueryFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
