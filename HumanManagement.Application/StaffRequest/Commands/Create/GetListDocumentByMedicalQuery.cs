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
    public class GetListDocumentByMedicalQuery : IRequest<Result>
    {
        public int id { get; set; }
    }

    public class GetListDocumentByMedicalQueryHandler : IRequestHandler<GetListDocumentByMedicalQuery, Result>
    {
        private readonly IRequestMedicalRepository _baseStaffRequestRepository;
        public GetListDocumentByMedicalQueryHandler(IRequestMedicalRepository employeeRepository)
        {
            this._baseStaffRequestRepository = employeeRepository;
        }

        public async Task<Result> Handle(GetListDocumentByMedicalQuery query, CancellationToken cancellationToken)
        {
            var list = await _baseStaffRequestRepository.ListDocumentByMedical(query.id);
            return new Result
            {
                StateCode = 200,
                Data = list
            };
        }
    }
}
