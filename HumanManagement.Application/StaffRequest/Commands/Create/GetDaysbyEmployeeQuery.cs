using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class GetDaysbyEmployeeQuery : IRequest<Result>
    {
        public int payload { get; set; }
    }
    public class GetDaysbyEmployeeQueryHandler : IRequestHandler<GetDaysbyEmployeeQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public GetDaysbyEmployeeQueryHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(GetDaysbyEmployeeQuery request, CancellationToken cancellationToken)
        {

            var days = await _requestMedicalRepository.GetDays(request.payload);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = days
            };
        }
    }
}
