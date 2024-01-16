using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class InsertStudenEmployeeQuery : IRequest<Result>
    {
        public EmployeeInsRequestDto payload { get; set; }
        public class InsertStudenEmployeeQueryHandler : IRequestHandler<InsertStudenEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public InsertStudenEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(InsertStudenEmployeeQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.InsertStudenEmployee(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
