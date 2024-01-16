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
    public class ListMasterTableGeneriicByKeyQuery : IRequest<Result>
    {
        public string key { get; set; }
        public class ListMasterTableGeneriicByKeyQueryHandler : IRequestHandler<ListMasterTableGeneriicByKeyQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public ListMasterTableGeneriicByKeyQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListMasterTableGeneriicByKeyQuery query, CancellationToken cancellationToken)
            {
                var listemployee = await _employeeRepository.GenericListMasterTableByKey(query.key);
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listemployee }
                };
            }
        }
    }
}
