using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestEmployeeByIdQuery : IRequest<Result>
    {
        public class GetStaffRequestEmployeeByIdQueryhandler : IRequestHandler<GetStaffRequestEmployeeByIdQuery, Result>
        {
            protected readonly SessionManager sessionManager;
            private readonly IStaffRequestRepository staffRequestRepository;
            public GetStaffRequestEmployeeByIdQueryhandler(IStaffRequestRepository staffRequestRepository,
                                                           SessionManager sessionManager)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetStaffRequestEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var employee = await staffRequestRepository.GetEmployeeById(sessionManager.User.IdEmployee);
                employee.SetDateAdmissionToString();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = employee
                };
            }
        }
    }
}
