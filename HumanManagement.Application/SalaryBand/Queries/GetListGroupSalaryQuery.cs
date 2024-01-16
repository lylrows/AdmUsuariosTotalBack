using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.SalaryBand.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{

    public class GetListGroupSalaryQuery : IRequest<Result>
    {
        public class GetListGroupSalaryQueryHandler : IRequestHandler<GetListGroupSalaryQuery, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;
            public GetListGroupSalaryQueryHandler(ISalaryBandRepository salarybandRepository)
            {
                this._salarybandRepository = salarybandRepository;
            }
            public async Task<Result> Handle(GetListGroupSalaryQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _salarybandRepository.GetListGroupSalary();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
