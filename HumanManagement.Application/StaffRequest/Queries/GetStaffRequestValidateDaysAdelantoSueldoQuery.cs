using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Application.Response;
using HumanManagement.Application.Helpers;
using HumanManagement.CrossCutting.Utils;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestValidateDaysAdelantoSueldoQuery : IRequest<Result>
    {
        public StaffRequestValidateDaysRequest filter { get; set; }
        public class GetStaffRequestValidateDaysAdelantoSueldoQueryHandler : IRequestHandler<GetStaffRequestValidateDaysAdelantoSueldoQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            public GetStaffRequestValidateDaysAdelantoSueldoQueryHandler(IStaffRequestRepository staffRequestRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
            }
            public async Task<Result> Handle(GetStaffRequestValidateDaysAdelantoSueldoQuery request, CancellationToken cancellationToken)
            {
                var result = await staffRequestRepository.GetStaffRequestValidateDaysAdelantoSueldo(request.filter.nidemployee);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }

    }
}