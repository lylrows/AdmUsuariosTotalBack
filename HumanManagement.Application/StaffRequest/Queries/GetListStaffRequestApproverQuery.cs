using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetListStaffRequestApproverQuery : IRequest<Result>
    {
        public int IdStaffRequest { get; set; }

        public class GetListStaffRequestApproverQueryHandler : IRequestHandler<GetListStaffRequestApproverQuery, Result>
        {
            private readonly IStaffRequestApproverRepository staffRequestApproverRepository;
            public GetListStaffRequestApproverQueryHandler(IStaffRequestApproverRepository staffRequestApproverRepository)
            {
                this.staffRequestApproverRepository = staffRequestApproverRepository;
            }
            public async Task<Result> Handle(GetListStaffRequestApproverQuery request, CancellationToken cancellationToken)
            {
                var list = await staffRequestApproverRepository.GetListById(request.IdStaffRequest);
                list.ForEach(x =>
                {
                    x.SetStateName();
                    x.ConvertReviewDateToString();
                });

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
