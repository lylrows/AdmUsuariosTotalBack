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
    public class GetListtStudenEmployeeQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }
        public class GetListtStudenEmployeeQueryHandler : IRequestHandler<GetListtStudenEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetListtStudenEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetListtStudenEmployeeQuery query, CancellationToken cancellationToken)
            {
                var data = await _employeeRepository.GetListStudenEmplooyee(query.nid_employee);
                return new Result
                {
                    StateCode = 200,
                    Data = data
                };
            }
        }
    }
}
