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
    public class RegisterRequestDocumentCommand : IRequest<Result>
    {
        public RegisterDocumentMedicalDto payload { get; set; }
        public IFormFile file { get; set; }
        public bool bIsDraft { get; set; }
    }
    public class RegisterRequestDocumentCommandHandler : IRequestHandler<RegisterRequestDocumentCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public RegisterRequestDocumentCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(RegisterRequestDocumentCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.RegisterDocumentMedical(request.payload, request.file,request.bIsDraft);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
