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
    public class UpdateStudenEmployeeQuery : IRequest<Result>
    {
        public EmployeeEditRequestDto payload { get; set; }
        public class UpdateStudenEmployeeQueryHandler : IRequestHandler<UpdateStudenEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public UpdateStudenEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(UpdateStudenEmployeeQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.UpdateStudenEmployee(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
