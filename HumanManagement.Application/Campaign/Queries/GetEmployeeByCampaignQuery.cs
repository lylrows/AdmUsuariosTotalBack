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
    public class GetEmployeeByCampaignQuery : IRequest<Result>
    {

        public EmployeeByCampaignFilterDto campaignQueryFilter { get; set; }
        public class GetEmployeeByCampaignQueryHandler : IRequestHandler<GetEmployeeByCampaignQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetEmployeeByCampaignQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetEmployeeByCampaignQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetEmployeeByCampaign(request.campaignQueryFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
