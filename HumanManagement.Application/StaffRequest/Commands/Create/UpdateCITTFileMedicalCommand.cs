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
    public class UpdateCITTFileMedicalCommand : IRequest<Result>
    {
        public UpdateCITTMedicalDto payload { get; set; }
        public IFormFile file { get; set; }
    }
    public class UpdateCITTFileMedicalCommandHandler : IRequestHandler<UpdateCITTFileMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateCITTFileMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(UpdateCITTFileMedicalCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.UpdateCITT(request.payload, request.file);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
