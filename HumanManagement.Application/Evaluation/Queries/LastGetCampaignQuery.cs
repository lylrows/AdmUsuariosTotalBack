using HumanManagement.Application.Response;
using HumanManagement.Domain.Campaign.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Evaluation.Queries
{
    public class LastGetCampaignQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }
        public class LastGetCampaignQueryHandler : IRequestHandler<LastGetCampaignQuery, Result>
        {
            private readonly ICampaignRepository _employeeRepository;
            public LastGetCampaignQueryHandler(ICampaignRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(LastGetCampaignQuery query, CancellationToken cancellationToken)
            {
                var data = await _employeeRepository.LastCampaignByEmployee(query.nid_employee);
                return new Result
                {
                    StateCode = 200,
                    Data = data
                };
            }
        }
    }
}
