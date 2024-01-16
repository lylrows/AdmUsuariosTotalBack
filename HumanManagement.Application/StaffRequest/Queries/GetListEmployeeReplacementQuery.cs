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
    public class GetListEmployeeReplacementQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class GetListEmployeeReplacementQueryHandler : IRequestHandler<GetListEmployeeReplacementQuery, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public GetListEmployeeReplacementQueryHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListEmployeeReplacementQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListEmployeeReplacement(query.Id);
            return new Result
            {
                StateCode = 200,
                Data = list
            };

        }
    }
}
