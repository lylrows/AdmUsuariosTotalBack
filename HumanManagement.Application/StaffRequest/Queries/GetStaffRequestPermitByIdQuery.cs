using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestPermitByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetStaffRequestPermitByIdQueryHandler : IRequestHandler<GetStaffRequestPermitByIdQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly IStaffRequestPermitRepository staffRequestPermitRepository;
            public GetStaffRequestPermitByIdQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                        IStaffRequestPermitRepository staffRequestPermitRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.staffRequestPermitRepository = staffRequestPermitRepository;
            }
            public async Task<Result> Handle(GetStaffRequestPermitByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequestPermit = await staffRequestPermitRepository.GetById(request.Id);
                var staffRequest = await staffRequestRepository.GetById(request.Id);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
                staffRequestPermit.StaffRequest = staffRequest;

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = staffRequestPermit
                };
            }
        }
    }
}