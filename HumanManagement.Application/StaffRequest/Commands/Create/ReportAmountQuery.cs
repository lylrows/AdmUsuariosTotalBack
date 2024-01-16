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
    public class ReportAmountQuery : IRequest<Result>
    {
    }

    public class ReportAmountQueryHandler : IRequestHandler<ReportAmountQuery, Result>
    {
        private readonly IRequestMedicalRepository _baseStaffRequestRepository;
        public ReportAmountQueryHandler(IRequestMedicalRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(ReportAmountQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ReportAmount();
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
