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
namespace HumanManagement.Application.Evaluation.Queries
{

    public class GetCampaingEvaluationAlertQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }
        public class GetMyEvaluationQueryHandler : IRequestHandler<GetCampaingEvaluationAlertQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetMyEvaluationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetCampaingEvaluationAlertQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetCampaingEvaluationAlert(request.nid_employee);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
