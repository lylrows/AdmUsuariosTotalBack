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
    public class GetStaffRequestListPaginationByUserQuery : IRequest<Result>
    {
        public StaffRequestQueryFilter StaffRequestQueryFilter { get; set; }
        public class GetStaffRequestListPaginationByUserQueryHandler : IRequestHandler<GetStaffRequestListPaginationByUserQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly SessionManager sessionManager;
            public GetStaffRequestListPaginationByUserQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                            SessionManager sessionManager)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetStaffRequestListPaginationByUserQuery request, CancellationToken cancellationToken)
            {
                request.StaffRequestQueryFilter.IdUser = sessionManager.User.IdUser;
                var list = await staffRequestRepository.GetListPaginationByUser(request.StaffRequestQueryFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }

    }
}
