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
    public class GetListCampaignPaginationQuery : IRequest<Result>
    {
        public CampaignQueryFilterDto campaignQueryFilter { get; set; }
        public class GetListCampaignPaginationQueryHandler : IRequestHandler<GetListCampaignPaginationQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            public GetListCampaignPaginationQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }
         

            public async Task<Result> Handle(GetListCampaignPaginationQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _campaignRepository.GetListUsersPagination(request.campaignQueryFilter);

                if ( resultPagination != null )
                {
                    foreach(var item in resultPagination.list)
                    {
                        var count = await _campaignRepository.GetCampaignCount(item.Id_Campaign);
                        item.T0 = count.T0;
                        item.T1 = count.T1;
                        item.T2 = count.T2;
                        item.porcentaje0 = count.porcentaje0;
                        item.porcentaje1 = count.porcentaje1;
                        item.porcentaje2 = count.porcentaje2;
                        item.completedt0 = count.completedt0;
                        item.completedt1 = count.completedt1;
                        item.completedt2 = count.completedt2;
                    }
                }
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
