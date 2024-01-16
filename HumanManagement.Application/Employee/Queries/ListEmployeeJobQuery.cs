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
    public class ListEmployeeJobQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }
        public class ListEmployeeJobQueryHandler : IRequestHandler<ListEmployeeJobQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public ListEmployeeJobQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListEmployeeJobQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.ListJob(query.nid_employee);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
