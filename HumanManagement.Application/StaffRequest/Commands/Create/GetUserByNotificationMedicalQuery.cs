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
    public class GetUserByNotificationMedicalQuery : IRequest<Result>
    {
    }

    public class GetUserByNotificationMedicalQueryHandler : IRequestHandler<GetUserByNotificationMedicalQuery, Result>
    {
        private readonly IRequestMedicalRepository _baseStaffRequestRepository;
        public GetUserByNotificationMedicalQueryHandler(IRequestMedicalRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetUserByNotificationMedicalQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListMedicalNotification();
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
