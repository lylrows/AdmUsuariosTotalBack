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
    public class GetStaffRequestAccountChangeCtsByIdQuery: IRequest<Result>
    {
        public int Id { get; set; }
        public class GetStaffRequestAccountChangeCtsByIdQueryHandler : IRequestHandler<GetStaffRequestAccountChangeCtsByIdQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly IStaffRequestAccountChangeCtsRepository staffRequestAccountChangeCtsRepository;
            public GetStaffRequestAccountChangeCtsByIdQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                                   IStaffRequestAccountChangeCtsRepository staffRequestAccountChangeCtsRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.staffRequestAccountChangeCtsRepository = staffRequestAccountChangeCtsRepository;
            }
            public async Task<Result> Handle(GetStaffRequestAccountChangeCtsByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequestAccountChangeCts = await staffRequestAccountChangeCtsRepository.GetById(request.Id);
                var staffRequest = await staffRequestRepository.GetById(request.Id);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
                staffRequestAccountChangeCts.StaffRequest = staffRequest;

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = staffRequestAccountChangeCts
                };
            }
        }

    }
}
