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
    public class GetListDetailHourExtraQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }
    }

    public class GetListDetailHourExtraQueryHandler : IRequestHandler<GetListDetailHourExtraQuery, Result>
    {
        private readonly IStaffRequestRepository _baseStaffRequestRepository;
        public GetListDetailHourExtraQueryHandler(IStaffRequestRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListDetailHourExtraQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.GetRequestHourExtraById(query.IdRequest);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
