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
    public class GetStaffSalaryByIdQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }

        public class GetStaffSalaryByIdQueryHandler : IRequestHandler<GetStaffSalaryByIdQuery, Result>
        {
            private readonly IStaffRequestRepository typeStaffRequestRepository;
            public GetStaffSalaryByIdQueryHandler(IStaffRequestRepository typeStaffRequestRepository)
            {
                this.typeStaffRequestRepository = typeStaffRequestRepository;
            }
            public async Task<Result> Handle(GetStaffSalaryByIdQuery request, CancellationToken cancellationToken)
            {
                var list = await typeStaffRequestRepository.GetStaffSalaryById(request.IdRequest);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
