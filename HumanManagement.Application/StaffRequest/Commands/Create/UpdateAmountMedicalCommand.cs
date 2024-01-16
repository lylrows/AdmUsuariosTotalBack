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
    public class UpdateAmountMedicalCommand : IRequest<Result>
    {
        public UpdateAmountMedicalDto payload { get; set; }
    }
    public class UpdateAmountMedicalCommandHandler : IRequestHandler<UpdateAmountMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateAmountMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(UpdateAmountMedicalCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.UpdateAmount(request.payload);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
