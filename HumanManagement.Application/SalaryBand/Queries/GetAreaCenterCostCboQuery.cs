using HumanManagement.Application.Response;
using HumanManagement.Domain.SalaryBand.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{

    public class GetAreaCenterCostCboQuery : IRequest<Result>
    {
        public int nid_areagroup { get; set; }

        public class GetAreaCenterCostCboQueryHandler : IRequestHandler<GetAreaCenterCostCboQuery, Result>
        {
            
            private readonly ISalaryBandRepository _salarybandRepository;
            public GetAreaCenterCostCboQueryHandler(ISalaryBandRepository _salarybandRepository)
            {
                this._salarybandRepository = _salarybandRepository;
            }
            public async Task<Result> Handle(GetAreaCenterCostCboQuery query, CancellationToken cancellationToken)
            {
                var listEntity = await _salarybandRepository.GetListAreaGroupCenterCost(query.nid_areagroup);

                return new Result
                {
                    StateCode = 200,
                    Data = listEntity
                };

            }
        }
    }
}
