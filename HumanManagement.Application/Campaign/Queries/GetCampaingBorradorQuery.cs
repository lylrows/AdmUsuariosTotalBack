using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{
    public class GetCampaingBorradorQuery : IRequest<Result>
    {

        public int IdEmployee { get; set; }
        public class GetCampaingBorradorQueryHandler : IRequestHandler<GetCampaingBorradorQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetCampaingBorradorQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetCampaingBorradorQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.ListCampaingBorrador(request.IdEmployee);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
