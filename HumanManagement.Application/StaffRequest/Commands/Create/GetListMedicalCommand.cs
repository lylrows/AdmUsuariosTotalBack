using HumanManagement.Application.Response;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class GetListMedicalCommand : IRequest<Result>
    {
        public FilterListDocumentDto payload { get; set; }
    }

    public class GetListMedicalCommandHandler : IRequestHandler<GetListMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _baseStaffRequestRepository;
        public GetListMedicalCommandHandler(IRequestMedicalRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListMedicalCommand query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListMedical(query.payload);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
