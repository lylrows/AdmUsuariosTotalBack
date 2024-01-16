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
    public class GetListCategoryRequest : IRequest<Result>
    {
    }

    public class GetListCategoryRequestHandler : IRequestHandler<GetListCategoryRequest, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public GetListCategoryRequestHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListCategoryRequest query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListCategoryRequest();
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
