using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class GetListCompanyComboQuery : IRequest<Result>
    {
        public class GetListCompanyComboQueryHandler : IRequestHandler<GetListCompanyComboQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetListCompanyComboQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetListCompanyComboQuery query, CancellationToken cancellationToken)
            {
                var listemployee = await _employeeRepository.GetListCompanyCombo();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listemployee }
                };
            }
        }
    }
}
