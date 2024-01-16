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
    public class GetTypeStaffRequestForSelectQuery : IRequest<Result>
    {

    }

    public class GetTypeStaffRequestForSelectQueryHandler : IRequestHandler<GetTypeStaffRequestForSelectQuery, Result>
    {
        private readonly ITypeStaffRequestRepository typeStaffRequestRepository;
        public GetTypeStaffRequestForSelectQueryHandler(ITypeStaffRequestRepository typeStaffRequestRepository)
        {
            this.typeStaffRequestRepository = typeStaffRequestRepository;
        }
        public async Task<Result> Handle(GetTypeStaffRequestForSelectQuery request, CancellationToken cancellationToken)
        {
            var list = await typeStaffRequestRepository.GetForSelect();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = list
            };
        }
    }
}
