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
    public class UpdateVIVAFileMedicalCommand : IRequest<Result>
    {
        public UpdateVIVAMedical payload { get; set; }
        public IFormFile file { get; set; }
    }
    public class UpdateVIVAFileMedicalCommandHandler : IRequestHandler<UpdateVIVAFileMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateVIVAFileMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(UpdateVIVAFileMedicalCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.UpdateVIVA(request.payload, request.file);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
