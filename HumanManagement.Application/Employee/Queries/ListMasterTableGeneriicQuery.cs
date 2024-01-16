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
    public class ListMasterTableGeneriicQuery : IRequest<Result>
    {
        public int id { get; set; } 
        public class ListMasterTableGeneriicQueryHandler : IRequestHandler<ListMasterTableGeneriicQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public ListMasterTableGeneriicQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListMasterTableGeneriicQuery query, CancellationToken cancellationToken)
            {
                var listemployee = await _employeeRepository.GenericListMasterTable(query.id);
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listemployee }
                };
            }
        }
    }
}
