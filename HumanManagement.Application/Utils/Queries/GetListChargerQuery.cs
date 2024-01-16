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
    public class GetListChargerQuery : IRequest<Result>
    {
        public class GetListChargerQueryHandler : IRequestHandler<GetListChargerQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListChargerQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListChargerQuery query, CancellationToken cancellationToken)
            {
                var listarea = await _utilRepository.GetCharger();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listarea }
                };
            }
        }
    }
}
