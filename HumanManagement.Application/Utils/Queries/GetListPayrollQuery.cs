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
    public class GetListPayrollQuery : IRequest<Result>
    {
        public class GetListPayrollQueryHandler : IRequestHandler<GetListPayrollQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListPayrollQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListPayrollQuery query, CancellationToken cancellationToken)
            {
                var listpayroll = await _utilRepository.GetPayroll();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listpayroll }
                };
            }
        }
    }
}
