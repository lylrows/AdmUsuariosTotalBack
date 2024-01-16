using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class UploadFileQuery : IRequest<Result>
    {
        public IFormFile fle { get; set; }
        public class UploadFileQueryHandler : IRequestHandler<UploadFileQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public UploadFileQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(UploadFileQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.UploadFIle(query.fle);
                return new Result
                {
                    StateCode = 200,
                    Data = "Archivo subido correctamente"
                };
            }
        }
    }
}
