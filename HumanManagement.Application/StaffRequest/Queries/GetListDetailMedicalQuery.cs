using HumanManagement.Application.Response;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetListDetailMedicalQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }
    }

    public class GetListDetailMedicalQueryHandler : IRequestHandler<GetListDetailMedicalQuery, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public GetListDetailMedicalQueryHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListDetailMedicalQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.GetRequestMedicalById(query.IdRequest);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
