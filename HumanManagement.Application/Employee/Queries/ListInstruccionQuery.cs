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
    public class ListInstruccionQuery : IRequest<Result>
    {
        public class ListInstruccionQueryHandler : IRequestHandler<ListInstruccionQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public ListInstruccionQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListInstruccionQuery query, CancellationToken cancellationToken)
            {
                var detailtEmployee = await _employeeRepository.ListInstruccion();
                return new Result
                {
                    StateCode = 200,
                    Data = detailtEmployee
                };
            }
        }
    }
}
