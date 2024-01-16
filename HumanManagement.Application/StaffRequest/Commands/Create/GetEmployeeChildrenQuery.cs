using HumanManagement.Application.Helpers;
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
    public class GetEmployeeChildrenQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeChildrenQueryHandler : IRequestHandler<GetEmployeeChildrenQuery, Result>
    {
        private readonly IStaffRequestRepository staffRequestRepository;
        public GetEmployeeChildrenQueryHandler(IStaffRequestRepository staffRequestRepository)
        {
            this.staffRequestRepository = staffRequestRepository;
        }

        public async Task<Result> Handle(GetEmployeeChildrenQuery query, CancellationToken cancellationToken)
        {
            var employee = await staffRequestRepository.GetEmployeeById(query.Id);
            employee.SetDateAdmissionToString();
            return new Result
            {
                StateCode = 200,
                Data = employee
            };
        }
    }
}
