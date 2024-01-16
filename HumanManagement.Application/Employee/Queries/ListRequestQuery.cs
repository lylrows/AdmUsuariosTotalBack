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
    public class ListRequestQuery : IRequest<Result>
    {
        public RequestFilterDto payload { get; set; }
        public class ListRequestHandler : IRequestHandler<ListRequestQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            public ListRequestHandler(IRquestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(ListRequestQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.ListRequest(query.payload);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
