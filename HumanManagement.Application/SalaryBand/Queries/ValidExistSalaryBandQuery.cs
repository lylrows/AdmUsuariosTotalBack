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
    public class ValidExistSalaryBandQuery : IRequest<Result>
    {
        public int IdGroup { get; set; }
        public class ValidExistSalaryBandQueryHandler : IRequestHandler<ValidExistSalaryBandQuery, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;

            public ValidExistSalaryBandQueryHandler(ISalaryBandRepository salarybandRepository)
            {
                this._salarybandRepository = salarybandRepository;
            }
            public async Task<Result> Handle(ValidExistSalaryBandQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _salarybandRepository.FindSalaryBandByGroupActive( query.IdGroup);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination != null
                };
            }
        }
    }
}
