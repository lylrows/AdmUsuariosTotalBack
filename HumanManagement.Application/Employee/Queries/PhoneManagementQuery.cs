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
    public class PhoneManagementQuery : IRequest<Result>
    {
        public PhoneManagementDto payload { get; set; }
        public class PhoneManagementQueryHandler : IRequestHandler<PhoneManagementQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public PhoneManagementQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(PhoneManagementQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.PhoneMangement(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = "La accion se realizo correctamente"
                };
            }
        }
    }
}
