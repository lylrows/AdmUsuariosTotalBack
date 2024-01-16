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
    public class DeleteStaffRequestCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteStaffRequestCommandHandler : IRequestHandler<DeleteStaffRequestCommand, Result>
    {

        private readonly IStaffRequestRepository requestRepository;
        public DeleteStaffRequestCommandHandler(IStaffRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }
        public async Task<Result> Handle(DeleteStaffRequestCommand request, CancellationToken cancellationToken)
        {

            await requestRepository.DeleteStaffRequest(request.Id);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
