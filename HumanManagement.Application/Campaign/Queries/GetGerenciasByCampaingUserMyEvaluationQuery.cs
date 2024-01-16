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
    public class GetGerenciasByCampaingUserMyEvaluationQuery : IRequest<Result>
    {
        public GerenciasByCampaingUserMyEvaluationFilter gerenciasByCampaingUserMyEvaluationFilter { get; set; }
        public class GetGerenciasByCampaingUserMyEvaluationQueryHandler : IRequestHandler<GetGerenciasByCampaingUserMyEvaluationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetGerenciasByCampaingUserMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetGerenciasByCampaingUserMyEvaluationQuery request, CancellationToken cancellationToken)
            {
                var result = await _campaignRepository.GetGerenciasByCampaingUserMyEvaluation(request.gerenciasByCampaingUserMyEvaluationFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
