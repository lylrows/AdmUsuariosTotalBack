using HumanManagement.Application.Response;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class StaffRequestGetEmployeeQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
    }

    public class StaffRequestGetEmployeeQueryHandler : IRequestHandler<StaffRequestGetEmployeeQuery, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public StaffRequestGetEmployeeQueryHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(StaffRequestGetEmployeeQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListEmployeeChildren(query.Id, query.IdEmployee);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
