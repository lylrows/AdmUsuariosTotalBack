using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Update
{
    public class UpdateRequestMedicalStateCommand: IRequest<Result>
    {
        public int idmedical { get; set; }
    }

    public class UpdateRequestMedicalStateCommandHandler: IRequestHandler<UpdateRequestMedicalStateCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateRequestMedicalStateCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }

        public async Task<Result> Handle(UpdateRequestMedicalStateCommand request, CancellationToken cancellationToken)
        {

            await _requestMedicalRepository.UpdateStateRequestMedical(request.idmedical);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
