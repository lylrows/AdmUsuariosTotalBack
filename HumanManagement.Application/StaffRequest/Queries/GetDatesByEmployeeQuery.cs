using HumanManagement.Application.Response;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetDatesByEmployeeQuery : IRequest<Result>
    {
        public int IdEmployee { get; set; }
    }
    public class GetDatesByEmployeeQueryHandler : IRequestHandler<GetDatesByEmployeeQuery, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public GetDatesByEmployeeQueryHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetDatesByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.GetDatesByEmployee(request.IdEmployee);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
