using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{

    public class GetAllEmployeeQuery : IRequest<Result>
    {
        public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await _employeeRepository.GetAllEmployee();
                output.Data = result;
                return output;
            }
        }
    }
}
