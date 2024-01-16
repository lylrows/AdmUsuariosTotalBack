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
    public class GetListAreaQuery : IRequest<Result>
    {
        public class GetListAreaQueryHandler : IRequestHandler<GetListAreaQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListAreaQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListAreaQuery query, CancellationToken cancellationToken)
            {
                var listarea = await _utilRepository.GetListArea();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listarea }
                };
            }
        }
    }
}
