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
    public class GetDetailEmployeeQuery : IRequest<Result>
    {
        public int nid_person { get; set; }
        public class GetDetailEmployeeQueryHandler : IRequestHandler<GetDetailEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetDetailEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetDetailEmployeeQuery query, CancellationToken cancellationToken)
            {
                var detailtEmployee = await _employeeRepository.GetDetailEmployee(query.nid_person);
                return new Result
                {
                    StateCode = 200,
                    Data = detailtEmployee
                };
            }
        }
    }
}
