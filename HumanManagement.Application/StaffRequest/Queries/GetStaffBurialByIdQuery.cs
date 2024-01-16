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
    public class GetStaffBurialByIdQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }

        public class GetStaffBurialByIdQueryHandler : IRequestHandler<GetStaffBurialByIdQuery, Result>
        {
            private readonly IStaffRequestRepository typeStaffRequestRepository;
            public GetStaffBurialByIdQueryHandler(IStaffRequestRepository typeStaffRequestRepository)
            {
                this.typeStaffRequestRepository = typeStaffRequestRepository;
            }
            public async Task<Result> Handle(GetStaffBurialByIdQuery request, CancellationToken cancellationToken)
            {
                var list = await typeStaffRequestRepository.GetStaffBurialById(request.IdRequest);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
