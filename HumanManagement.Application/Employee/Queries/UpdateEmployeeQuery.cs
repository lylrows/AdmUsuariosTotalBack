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
    public class UpdateEmployeeQuery: IRequest<Result>
    {
        public UpdateEmployeeDto payload { get; set; }
        public class UpdateEmployeeQueryHandler : IRequestHandler<UpdateEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public UpdateEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(UpdateEmployeeQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.UpdateEmployee(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Empleado Actualizado Correctamente"
                };
            }
        }
    }
}
