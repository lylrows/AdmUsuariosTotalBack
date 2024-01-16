using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
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
    public class UpdateCITTMedicalCommand : IRequest<Result>
    {
        public UpdateCITTMedicalDto payload { get; set; }
    }
    public class UpdateCITTMedicalCommandHandler : IRequestHandler<UpdateCITTMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateCITTMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(UpdateCITTMedicalCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.UpdateCITT(request.payload, null);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
