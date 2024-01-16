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
    public class ListBankQuery : IRequest<Result>
    {
        public class ListBankQueryHandler : IRequestHandler<ListBankQuery, Result>
        {
            private readonly IStaffRequestRepository typeStaffRequestRepository;
            public ListBankQueryHandler(IStaffRequestRepository typeStaffRequestRepository)
            {
                this.typeStaffRequestRepository = typeStaffRequestRepository;
            }
            public async Task<Result> Handle(ListBankQuery request, CancellationToken cancellationToken)
            {
                var list = await typeStaffRequestRepository.ListBank();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
