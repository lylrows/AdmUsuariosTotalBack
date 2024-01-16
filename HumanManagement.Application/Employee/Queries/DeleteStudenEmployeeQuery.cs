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
    public class DeleteStudenEmployeeQuery : IRequest<Result>
    {
        public int nid_studen { get; set; }
        public class DeleteStudenEmployeeQueryHandler : IRequestHandler<DeleteStudenEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public DeleteStudenEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(DeleteStudenEmployeeQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.DeleteStudenEmployee(query.nid_studen);
                return new Result
                {
                    StateCode = 200,
                    Data = "Accion realizada con exito"
                };
            }
        }
    }
}
