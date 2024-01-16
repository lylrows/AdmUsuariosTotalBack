using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class RequestMedicalDocumentApprovedQuery : IRequest<Result>
    {
        public RequestDocumentApprovedDto payload { get; set; }
    }
    public class RequestMedicalDocumentApprovedQueryHandler : IRequestHandler<RequestMedicalDocumentApprovedQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public RequestMedicalDocumentApprovedQueryHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(RequestMedicalDocumentApprovedQuery request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.RequestDocumentApproved(request.payload);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
