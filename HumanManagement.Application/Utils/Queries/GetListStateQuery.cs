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
    public class GetListStateQuery : IRequest<Result>
    {
        public class GetListStateQueryHandler : IRequestHandler<GetListStateQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListStateQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListStateQuery query, CancellationToken cancellationToken)
            {
                var liststate = await _utilRepository.GetStatusEmployee();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = liststate }
                };
            }
        }
    }
}
