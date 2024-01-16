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
    public class UpdateEmployeeJobQuery : IRequest<Result>
    {
        public UpdateJobDto payload { get; set; }
        public class UpdateEmployeeJobQueryHandler : IRequestHandler<UpdateEmployeeJobQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public UpdateEmployeeJobQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(UpdateEmployeeJobQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.UpdateJob(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
