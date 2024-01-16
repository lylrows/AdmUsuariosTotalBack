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
    public class DetailRequestQuery : IRequest<Result>
    {
        public int id { get; set; }
        public class DetailRequestQueryHandler : IRequestHandler<DetailRequestQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            public DetailRequestQueryHandler(IRquestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(DetailRequestQuery query, CancellationToken cancellationToken)
            {
                var detail = await _employeeRepository.RequestDetail(query.id);
                return new Result
                {
                    StateCode = 200,
                    Data = detail
                };
            }
        }
    }
}
