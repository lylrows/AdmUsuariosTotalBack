using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetTypeStaffRequestEnabledQuery : IRequest<Result>
    {

        public class GetTypeStaffRequestEnabledQueryHandler : IRequestHandler<GetTypeStaffRequestEnabledQuery, Result>
        {
            private readonly ITypeStaffRequestRepository typeStaffRequestRepository;
            public GetTypeStaffRequestEnabledQueryHandler(ITypeStaffRequestRepository typeStaffRequestRepository)
            {
                this.typeStaffRequestRepository = typeStaffRequestRepository;
            }
            
            public async Task<Result> Handle(GetTypeStaffRequestEnabledQuery request, CancellationToken cancellationToken)
            {
                var list = await typeStaffRequestRepository.GetOnlyEnabled();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
