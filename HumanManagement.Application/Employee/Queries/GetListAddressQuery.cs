using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class GetListAddressQuery : IRequest<Result>
    {
        public int nid_person { get; set; }
        public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetListAddressQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetListAddressQuery query, CancellationToken cancellationToken)
            {
                var listaddress = await _employeeRepository.GetListAddressDto(query.nid_person);
                return new Result
                {
                    StateCode = 200,
                    Data = listaddress
                };
            }
        }
    }
}
