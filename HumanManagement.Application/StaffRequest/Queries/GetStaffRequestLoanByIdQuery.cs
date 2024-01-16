using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries 
{
    public class GetStaffRequestLoanByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetStaffRequestLoanByIdQueryHandler : IRequestHandler<GetStaffRequestLoanByIdQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly IStaffRequestLoanRepository staffRequestLoanRepository;
            public GetStaffRequestLoanByIdQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                       IStaffRequestLoanRepository staffRequestLoanRepository)
            {
                this.staffRequestRepository = staffRequestRepository;
                this.staffRequestLoanRepository = staffRequestLoanRepository;
            }
            public async Task<Result> Handle(GetStaffRequestLoanByIdQuery request, CancellationToken cancellationToken)
            {
                var staffRequestLoan = await staffRequestLoanRepository.GetById(request.Id); 
                var staffRequest = await staffRequestRepository.GetById(request.Id);
                staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
                staffRequestLoan.StaffRequest = staffRequest;
                var detailt = await staffRequestLoanRepository.GetDetailtById(request.Id);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = new { staffRequestLoan, detailt }
                };
            }
        }
    }
}
