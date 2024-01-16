using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestListPaginationQuery : IRequest<Result> 
    {
        public StaffRequestQueryFilter StaffRequestQueryFilter { get; set; }
        public class GetStaffRequestListPaginationQueryHandler : IRequestHandler<GetStaffRequestListPaginationQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly SessionManager sessionManager;
            public GetStaffRequestListPaginationQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                            SessionManager sessionManager)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetStaffRequestListPaginationQuery request, CancellationToken cancellationToken)
            {
                request.StaffRequestQueryFilter.IdUser = sessionManager.User.IdUser;
                var list = await staffRequestRepository.GetListPagination(request.StaffRequestQueryFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }

    }
}
