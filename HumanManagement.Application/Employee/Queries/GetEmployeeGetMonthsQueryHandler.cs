using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Application.Response;

namespace HumanManagement.Application.Employee.Queries
{
    public class GetEmployeeGetMonthsQuery : IRequest<Result>
    {
        public int nid_tipo_documento { get; set; }
        public int nyear { get; set; }
        public class GetEmployeeGetMonthsQueryHandler : IRequestHandler<GetEmployeeGetMonthsQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetEmployeeGetMonthsQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetEmployeeGetMonthsQuery query, CancellationToken cancellationToken)
            {
                var list_month = await _employeeRepository.GetMonthsByTipoDocumento(query.nid_tipo_documento, query.nyear);
                return new Result
                {
                    StateCode = 200,
                    Data = list_month
                };
            }
        }
    }
}

