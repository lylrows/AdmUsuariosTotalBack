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
    public class InsetSonQuery : IRequest<Result>
    {
        public InsertSonDto payload { get; set; }
        public class InsetSonQueryHandler : IRequestHandler<InsetSonQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public InsetSonQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(InsetSonQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.InsertSon(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
