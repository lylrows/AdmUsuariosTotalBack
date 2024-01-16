using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Person.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class ManagementAddressQuery: IRequest<Result>
    {
        public AddressManagementDto payload { get; set; }
        public class ManagementAddressQueryHandler : IRequestHandler<ManagementAddressQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public ManagementAddressQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ManagementAddressQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.AddressMangement(query.payload);
                return new Result
                {
                    StateCode = 200, 
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
