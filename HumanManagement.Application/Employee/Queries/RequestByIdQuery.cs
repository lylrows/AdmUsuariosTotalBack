using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Security.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.QueryFilter;

namespace HumanManagement.Application.Employee.Queries
{
    public class RequestByIdQuery : IRequest<Result>
    {
        public RequestByIdFilter filter { get; set; }
        public class RequestByIdQueryHandler : IRequestHandler<RequestByIdQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            public RequestByIdQueryHandler(IRquestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(RequestByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _employeeRepository.RequestById(query.filter.nid_request);
                return new Result
                {
                    StateCode = 200,
                    Data = result
                };
            }

        }
    }
}
