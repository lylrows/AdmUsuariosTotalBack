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
    public class DeleteEmployeeJobQuery : IRequest<Result>
    {
        public DeleteJobDto payload { get; set; }
        public class DeleteEmployeeJobQueryHandler : IRequestHandler<DeleteEmployeeJobQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public DeleteEmployeeJobQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(DeleteEmployeeJobQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.DeleteJob(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
