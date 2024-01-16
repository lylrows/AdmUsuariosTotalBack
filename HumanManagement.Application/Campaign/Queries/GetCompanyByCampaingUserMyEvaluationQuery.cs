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
    public class GetCompanyByCampaingUserMyEvaluationQuery : IRequest<Result>
    {
        public CompanyByCampaingUserMyEvaluationFilter companyByCampaingUserMyEvaluationFilter { get; set; }
        public class GetCompanyByCampaingUserMyEvaluationQueryHandler : IRequestHandler<GetCompanyByCampaingUserMyEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetCompanyByCampaingUserMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetCompanyByCampaingUserMyEvaluationQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetCompanyByCampaingUserMyEvaluation(request.companyByCampaingUserMyEvaluationFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
