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
    public class GetSalaryGroupComboQuery : IRequest<Result>
    {
        public class GetSalaryGroupComboQueryHandler : IRequestHandler<GetSalaryGroupComboQuery, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;
            public GetSalaryGroupComboQueryHandler(ISalaryBandRepository salarybandRepository)
            {
                this._salarybandRepository = salarybandRepository;
            }
            public async Task<Result> Handle(GetSalaryGroupComboQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _salarybandRepository.ListGroupCombo();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
