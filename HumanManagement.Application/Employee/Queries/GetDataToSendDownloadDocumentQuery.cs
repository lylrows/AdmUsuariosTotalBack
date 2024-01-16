using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class GetDataToSendDownloadDocumentQuery : IRequest<Result>
    {
        public int nid_request { get; set; }
        public class GetDataToSendDownloadDocumentQueryHandler : IRequestHandler<GetDataToSendDownloadDocumentQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetDataToSendDownloadDocumentQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetDataToSendDownloadDocumentQuery query, CancellationToken cancellationToken)
            {
                var listaddress = await _employeeRepository.GetDataToSendDownloadDocument(query.nid_request);
                return new Result
                {
                    StateCode = 200,
                    Data = listaddress
                };
            }
        }
    }
}
