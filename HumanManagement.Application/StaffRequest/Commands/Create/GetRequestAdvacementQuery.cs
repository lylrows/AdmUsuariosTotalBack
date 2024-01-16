using HumanManagement.Application.Response;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class GetRequestAdvacementQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }
        public class GetRequestAdvacementQueryHandler : IRequestHandler<GetRequestAdvacementQuery, Result>
        {
            private readonly IStaffRequestRepository _employeeRepository;
            public GetRequestAdvacementQueryHandler(IStaffRequestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetRequestAdvacementQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.GetRequestAdvance(query.IdRequest);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
