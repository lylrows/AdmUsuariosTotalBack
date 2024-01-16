using HumanManagement.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using HumanManagement.Domain.StaffRequest.Contracts;
using System.Threading.Tasks;
using System.Threading;

namespace HumanManagement.Application.StaffRequest.Queries
{

    public class GetApprovalDateQuery : IRequest<Result>
    {
        public int id { get; set; }
    }

    public class GetApprovalDateQueryHandler : IRequestHandler<GetApprovalDateQuery, Result>
    {
        private readonly IRequestMedicalRepository _baseStaffRequestRepository;
        public GetApprovalDateQueryHandler(IRequestMedicalRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetApprovalDateQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.GetApprovalDate(query.id);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
