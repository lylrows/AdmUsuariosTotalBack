using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Application.Response;
using HumanManagement.Application.Helpers;
using HumanManagement.CrossCutting.Utils;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetStaffRequestFromNotificacionQuery : IRequest<Result>
    {
        public StaffRequestFromNotificacionFilter filter { get; set; }
        public class GetStaffRequestFromNotificacionQueryHandler : IRequestHandler<GetStaffRequestFromNotificacionQuery, Result>
        {
            private readonly IStaffRequestRepository staffRequestRepository;
            private readonly SessionManager sessionManager;
            public GetStaffRequestFromNotificacionQueryHandler(IStaffRequestRepository staffRequestRepository,
                                                            SessionManager sessionManager
                )
            {
                this.staffRequestRepository = staffRequestRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetStaffRequestFromNotificacionQuery request, CancellationToken cancellationToken)
            {
                request.filter.nid_user = sessionManager.User.IdUser;
                var list = await staffRequestRepository.GetStaffRequestFromNotificacion(request.filter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }

    }
}
