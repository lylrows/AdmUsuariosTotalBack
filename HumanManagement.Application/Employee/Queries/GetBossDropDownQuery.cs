using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
  
    public class GetBossDropDownQuery : IRequest<Result>
    {
        public int nidPosition { get; set; }
        public class GetBossDropDownQueryHandler : IRequestHandler<GetBossDropDownQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetBossDropDownQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetBossDropDownQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.GetBossDropDown(query.nidPosition);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
