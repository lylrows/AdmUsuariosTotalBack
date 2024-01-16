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
    public class GetListRequestByCategoryQuery : IRequest<Result>
    {
        public int IdCategory { get; set; }
    }

    public class GetListRequestByCategoryQueryHandler : IRequestHandler<GetListRequestByCategoryQuery, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public GetListRequestByCategoryQueryHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListRequestByCategoryQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListRequestByCategory(query.IdCategory);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
