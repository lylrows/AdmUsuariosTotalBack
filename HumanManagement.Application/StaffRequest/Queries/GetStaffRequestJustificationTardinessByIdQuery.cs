using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestJustificationTardinessByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetStaffRequestJustificationTardinessByIdQueryHandler : IRequestHandler<GetStaffRequestJustificationTardinessByIdQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly IStaffRequestJustificationTardinessRepository staffRequestJustificationTardinessRepository;
            public GetStaffRequestJustificationTardinessByIdQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                                        IStaffRequestJustificationTardinessRepository staffRequestJustificationTardinessRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.staffRequestJustificationTardinessRepository = staffRequestJustificationTardinessRepository;
            }
            public async Task<Result> Handle(GetStaffRequestJustificationTardinessByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequestJustificationTardiness = await staffRequestJustificationTardinessRepository.GetById(request.Id);
                var staffRequest = await staffRequestRepository.GetById(request.Id);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
                staffRequestJustificationTardiness.StaffRequest = staffRequest;

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = staffRequestJustificationTardiness
                };
            }
        }
    }
}
