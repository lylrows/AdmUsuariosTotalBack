using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetApproverAccessQuery : IRequest<Result>
    {
        public int IdStaffRequest { get; set; }
    }

    public class GetApproverAccessQueryHandler : IRequestHandler<GetApproverAccessQuery, Result>
    {
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestApproverRepository staffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly SessionManager sessionManager;
        private readonly IUtilRepository _utilRepository;
        public GetApproverAccessQueryHandler(ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                             IStaffRequestApproverRepository staffRequestApproverRepository,
                                             IStaffRequestRepository staffRequestRepository,
                                            SessionManager sessionManager,
                                                    IUtilRepository utilRepository)
        {
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestApproverRepository = staffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.sessionManager = sessionManager;
            this._utilRepository = utilRepository;
        }

        public async Task<Result> Handle(GetApproverAccessQuery request, CancellationToken cancellationToken)
        {
            var requestApproverList = await staffRequestApproverRepository.GetListById(request.IdStaffRequest);
            var staffRequest = await staffRequestRepository.GetById(request.IdStaffRequest);
            int nextLevel = requestApproverList.Count + 1;
            var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, nextLevel);
            bool hasAccessToApprover = false;
            if (approver != null)
            { 
                //int idArea = approver.AllowApproveAll ? 0 : staffRequest.StaffRequestEmployee.IdArea;
                int idArea = staffRequest.StaffRequestEmployee.IdArea;
                var approverList = await staffRequestRepository.GetListReceptorForNotification(approver.IdProfile, idArea);
                if (approver.AllowApproveAll)
                {
                    hasAccessToApprover = approverList
                                      .Any(x => x.IdReceptor == sessionManager.User.IdPerson);
                }
                else
                {
                    hasAccessToApprover = approverList
                                      .Any(x => x.IdReceptor == sessionManager.User.IdPerson
                                      && x.IdArea == staffRequest.StaffRequestEmployee.IdArea);
                }
                
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = hasAccessToApprover
            };
        }
    }
}
