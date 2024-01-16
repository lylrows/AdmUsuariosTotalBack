using HumanManagement.Application.Response;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Queries
{
    public class GetListCostCenterQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class GetListCostCenterQueryHandler : IRequestHandler<GetListCostCenterQuery, Result>
    {
        private readonly IUtilRepository _utilRepository;
        public GetListCostCenterQueryHandler(IUtilRepository utilRepository)
        {
            this._utilRepository = utilRepository;
        }

        public async Task<Result> Handle(GetListCostCenterQuery query, CancellationToken cancellationToken)
        {
            var listcostcenter = await _utilRepository.GetListCostCenter(query.Id);
            return new Result
            {
                StateCode = 200,
                Data = new { data = listcostcenter }
            };
        }
    }
}
