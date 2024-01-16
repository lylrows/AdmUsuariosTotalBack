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
    public class ListRequestPaginationQuery : IRequest<Result>
    {
        public EmployeeQueryFilter EmployeeQueryFilter { get; set; }
        public class ListRequestHandler : IRequestHandler<ListRequestPaginationQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            public ListRequestHandler(IRquestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListRequestPaginationQuery query, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(query.EmployeeQueryFilter.dateEnd))
                {
                    DateTime dateStart = DateTime.Parse(query.EmployeeQueryFilter.dateStart);
                    query.EmployeeQueryFilter.dateStart = dateStart.ToString("yyyy-MM-dd");
                    DateTime dateEnd = DateTime.Parse(query.EmployeeQueryFilter.dateEnd);
                    query.EmployeeQueryFilter.dateEnd = dateEnd.ToString("yyyy-MM-dd");

                }
                
                var list = await _employeeRepository.ListRequestPagination(query.EmployeeQueryFilter);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }

        }
    }
}
