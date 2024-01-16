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
    public class GetListPositionComboQuery : IRequest<Result>
    {
        public int nid_company { get; set; }
        public class GetListPositionComboQueryHandler : IRequestHandler<GetListPositionComboQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetListPositionComboQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetListPositionComboQuery query, CancellationToken cancellationToken)
            {
                var listemployee = await _employeeRepository.GetListPositionCombo(query.nid_company);
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listemployee }
                };
            }
        }
    }
}
