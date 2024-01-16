using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestAbsenceByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetStaffRequestAbsenceByIdQueryHandler : IRequestHandler<GetStaffRequestAbsenceByIdQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly IStaffRequestAbsenceRepository staffRequestAbsenceRepository;
            public GetStaffRequestAbsenceByIdQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                          IStaffRequestAbsenceRepository staffRequestAbsenceRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.staffRequestAbsenceRepository = staffRequestAbsenceRepository;
            }
            public async Task<Result> Handle(GetStaffRequestAbsenceByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequestAbsence = await staffRequestAbsenceRepository.GetById(request.Id);
                var staffRequest = await staffRequestRepository.GetById(request.Id);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
                staffRequestAbsence.StaffRequest = staffRequest;

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = staffRequestAbsence
                };
            }
        }

    }
}
