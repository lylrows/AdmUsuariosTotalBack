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
    public class GetListSexQuery : IRequest<Result>
    {
        public class GetListSexQueryHandler : IRequestHandler<GetListSexQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListSexQueryHandler(IUtilRepository utilRepository)
            { 
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListSexQuery query, CancellationToken cancellationToken)
            {
                var listsex = await _utilRepository.GetListSex();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listsex }
                };
            }
        }
    }
}
