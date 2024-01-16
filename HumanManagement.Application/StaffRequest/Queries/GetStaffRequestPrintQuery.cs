using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestPrintQuery : IRequest<Result>
    {
        public StaffRequestQueryFilter StaffRequestQueryFilter { get; set; }
        public class GetStaffRequestPrintQueryHandler : IRequestHandler<GetStaffRequestPrintQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly SessionManager sessionManager;
            public GetStaffRequestPrintQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                            SessionManager sessionManager)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetStaffRequestPrintQuery request, CancellationToken cancellationToken)
            {
                request.StaffRequestQueryFilter.IdUser = sessionManager.User.IdUser;
                var list = await staffRequestRepository.GetListRequestPrint(request.StaffRequestQueryFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
