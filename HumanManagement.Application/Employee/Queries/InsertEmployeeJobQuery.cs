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
    public class InsertEmployeeJobQuery : IRequest<Result>
    {
        public InsertJobDto payload { get; set; }
        public class InsertEmployeeJobQueryHandler : IRequestHandler<InsertEmployeeJobQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public InsertEmployeeJobQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(InsertEmployeeJobQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.InsertJob(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
