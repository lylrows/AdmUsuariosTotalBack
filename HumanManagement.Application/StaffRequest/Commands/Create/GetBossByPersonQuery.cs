using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class GetBossByPersonQuery : IRequest<Result>
    {
        public int payload { get; set; }
    }
    public class GetBossByPersonQueryHandler : IRequestHandler<GetBossByPersonQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public GetBossByPersonQueryHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(GetBossByPersonQuery request, CancellationToken cancellationToken)
        {

            var boss = await _requestMedicalRepository.Getboss(request.payload);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = boss
            };
        }
    }
}
