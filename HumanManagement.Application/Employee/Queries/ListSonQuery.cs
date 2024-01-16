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
    public class ListSonQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }
        public class ListSonQueryHandler : IRequestHandler<ListSonQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public ListSonQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListSonQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.ListSon(query.nid_employee);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
