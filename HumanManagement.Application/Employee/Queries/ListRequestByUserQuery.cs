using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class ListRequestByUserQuery : IRequest<Result>
    {
        public EmployeeQueryFilter EmployeeQueryFilter { get; set; }
        public class ListRequestByUserQueryHandler : IRequestHandler<ListRequestByUserQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            public ListRequestByUserQueryHandler(IRquestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListRequestByUserQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.ListRequestByUser(query.EmployeeQueryFilter);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }

        }
    }
}
