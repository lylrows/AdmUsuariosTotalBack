using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestByIdQuery : IRequest<Result>
    {
        public int IdStaffRequest { get; set; }
        public class GetStaffRequestByIdQueryHandler : IRequestHandler<GetStaffRequestByIdQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            public GetStaffRequestByIdQueryHandler(IStaffRequestRepository staffRequestRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
            }
            public async Task<Result> Handle(GetStaffRequestByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequest = await staffRequestRepository.GetById(request.IdStaffRequest);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = staffRequest
                };
            }
        }
    }
}
