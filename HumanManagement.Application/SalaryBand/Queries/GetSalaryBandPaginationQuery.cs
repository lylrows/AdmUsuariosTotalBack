using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{
    public class GetSalaryBandPaginationQuery : IRequest<Result>
    {
        public SalaryBandQueryFilter salaryQueryFilter { get; set; }
        public class GetSalaryBandPaginationQueryHandler : IRequestHandler<GetSalaryBandPaginationQuery, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;
            public GetSalaryBandPaginationQueryHandler(ISalaryBandRepository salarybandRepository)
            {
                this._salarybandRepository = salarybandRepository;
            }
            public async Task<Result> Handle(GetSalaryBandPaginationQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _salarybandRepository.GetBandBoxPagination(query.salaryQueryFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
