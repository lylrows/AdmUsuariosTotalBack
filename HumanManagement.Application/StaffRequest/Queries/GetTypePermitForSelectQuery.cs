using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetTypePermitForSelectQuery : IRequest<Result>
    {
    }

    public class GetTypePermitForSelectQueryHandler : IRequestHandler<GetTypePermitForSelectQuery, Result>
    {
        private readonly IPermitTypeRepository permitTypeRepository;
        public GetTypePermitForSelectQueryHandler(IPermitTypeRepository permitTypeRepository)
        {
            this.permitTypeRepository = permitTypeRepository;
        }
        public async Task<Result> Handle(GetTypePermitForSelectQuery request, CancellationToken cancellationToken)
        {
            var list = await permitTypeRepository.GetForSelect();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = list
            };
        }
    }
}
