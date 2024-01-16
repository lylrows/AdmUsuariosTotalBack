using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetTypeStaffRequestListPaginationQuery : IRequest<Result>
    {
        public TypeStaffRequestQueryFilter TypeStaffRequestQueryFilter { get; set; }
        public class GetTypeStaffRequestListPaginationQueryHandler : IRequestHandler<GetTypeStaffRequestListPaginationQuery, Result>
        {
            private readonly ITypeStaffRequestRepository typeStaffRequestRepository;
            public GetTypeStaffRequestListPaginationQueryHandler(ITypeStaffRequestRepository typeStaffRequestRepository)
            {
                this.typeStaffRequestRepository = typeStaffRequestRepository;
            }
            public async Task<Result> Handle(GetTypeStaffRequestListPaginationQuery request, CancellationToken cancellationToken)
            {
                var list = await typeStaffRequestRepository.GetListPagination(request.TypeStaffRequestQueryFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }

    }
}
