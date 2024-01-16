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
    public class GetEmployeeFileQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }
        public class GetEmployeeFileQueryHandler : IRequestHandler<GetEmployeeFileQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetEmployeeFileQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetEmployeeFileQuery query, CancellationToken cancellationToken)
            {
                var detailtEmployee = await _employeeRepository.GetEmployeeFile(query.nid_employee);
                return new Result
                {
                    StateCode = 200,
                    Data = detailtEmployee
                };
            }
        }
    }
}
