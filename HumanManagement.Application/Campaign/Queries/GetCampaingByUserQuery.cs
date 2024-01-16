using HumanManagement.Domain.Campaign.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Dto;

namespace HumanManagement.Application.Campaign.Queries
{
    public class GetCampaingByUserQuery : IRequest<Result>
    {
        public CampaingByUserFilter filter { get; set; }
        public class GetCampaingByUserQueryHandler : IRequestHandler<GetCampaingByUserQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetCampaingByUserQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetCampaingByUserQuery request, CancellationToken cancellationToken)
            {

                var resultPagination = await _campaignRepository.GetCampaingByUser(request.filter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
