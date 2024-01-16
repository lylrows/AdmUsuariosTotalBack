using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetTypeStaffRequestByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }

        public class GetTypeStaffRequestByIdQueryHandler : IRequestHandler<GetTypeStaffRequestByIdQuery, Result>
        {
            private readonly ITypeStaffRequestRepository typeStaffRequestRepository;
            private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
            public GetTypeStaffRequestByIdQueryHandler(ITypeStaffRequestRepository typeStaffRequestRepository,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository)
            {
                this.typeStaffRequestRepository = typeStaffRequestRepository;
                this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            }
            public async Task<Result> Handle(GetTypeStaffRequestByIdQuery request, CancellationToken cancellationToken)
            {
                var typeStaffRequest = await typeStaffRequestRepository.GetById(request.Id);
                typeStaffRequest.TypeStaffRequestApproverList = await typeStaffRequestApproverRepository.GetListById(request.Id);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = typeStaffRequest
                };
            }
        }
    }
}
