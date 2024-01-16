using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class UpdateFirmaEmployeeQuery : IRequest<Result>
    {
        public UpdateCovidCardDto payload { get; set; }
        public IFormFile file { get; set; }
        public class UpdateCovidCardQueryHandler : IRequestHandler<UpdateFirmaEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public UpdateCovidCardQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(UpdateFirmaEmployeeQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.UpdateFirma(query.payload, query.file);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
