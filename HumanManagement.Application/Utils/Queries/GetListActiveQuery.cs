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
    public class GetListActiveQuery : IRequest<Result>
    {
        public class GetListActiveQueryHandler : IRequestHandler<GetListActiveQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListActiveQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListActiveQuery query, CancellationToken cancellationToken)
            {
                var listactive = await _utilRepository.GetListActive();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listactive }
                };
            }
        }
    }
}
