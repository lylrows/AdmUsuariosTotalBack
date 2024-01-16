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
    public class UpdateVIVAMedicalCommand : IRequest<Result>
    {
        public UpdateVIVAMedical payload { get; set; }
    }
    public class UpdateVIVAMedicalCommandHandler : IRequestHandler<UpdateVIVAMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateVIVAMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(UpdateVIVAMedicalCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.UpdateVIVA(request.payload, null);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
