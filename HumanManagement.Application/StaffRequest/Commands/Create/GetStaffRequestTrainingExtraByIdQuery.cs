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
    public class GetStaffRequestTrainingExtraByIdQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }
        public class GetStaffRequestTrainingExtraByIdQueryHandler : IRequestHandler<GetStaffRequestTrainingExtraByIdQuery, Result>
        {
            private readonly IStaffRequestRepository _employeeRepository;
            public GetStaffRequestTrainingExtraByIdQueryHandler(IStaffRequestRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetStaffRequestTrainingExtraByIdQuery query, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.GetRequestCapacitacionExtraById(query.IdRequest);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
