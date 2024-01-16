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
    public class UpdateSonQuery : IRequest<Result>
    {
        public UpdateSonDto payload { get; set; }
        public class UpdateSonQueryHandler : IRequestHandler<UpdateSonQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public UpdateSonQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(UpdateSonQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.UpdateSon(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
