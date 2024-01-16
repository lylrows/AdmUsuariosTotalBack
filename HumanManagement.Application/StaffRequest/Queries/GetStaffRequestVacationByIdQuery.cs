using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestVacationByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }

        public class GetStaffRequestVacationByIdQueryHandler : IRequestHandler<GetStaffRequestVacationByIdQuery, Result>
        {
            private readonly IStaffRequestVacationRepository staffRequestVacationRepository;
            private readonly IStaffRequestRepository staffRequestRepository;
            public GetStaffRequestVacationByIdQueryHandler(IStaffRequestVacationRepository staffRequestVacationRepository,
                                                            IStaffRequestRepository staffRequestRepository)
            {
                this.staffRequestVacationRepository = staffRequestVacationRepository;
                this.staffRequestRepository = staffRequestRepository;
            }
            public async Task<Result> Handle(GetStaffRequestVacationByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequestVacation = await staffRequestVacationRepository.GetById(request.Id);
                var staffRequest = await staffRequestRepository.GetById(request.Id);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
                staffRequestVacation.StaffRequest = staffRequest;

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = staffRequestVacation
                };
            }
        }
    }
}
