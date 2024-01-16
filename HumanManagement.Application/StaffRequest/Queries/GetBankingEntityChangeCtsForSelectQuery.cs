using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetBankingEntityChangeCtsForSelectQuery : IRequest<Result>
    {
    }

    public class GetBankingEntityChangeCtsForSelectQueryHandler : IRequestHandler<GetBankingEntityChangeCtsForSelectQuery, Result>
    {
        private readonly IBankingEntityChangeCtsRepository bankingEntityChangeCtsRepository;
        public GetBankingEntityChangeCtsForSelectQueryHandler(IBankingEntityChangeCtsRepository bankingEntityChangeCtsRepository)
        {
            this.bankingEntityChangeCtsRepository = bankingEntityChangeCtsRepository;
        }
        public async Task<Result> Handle(GetBankingEntityChangeCtsForSelectQuery request, CancellationToken cancellationToken)
        {
            var list = await bankingEntityChangeCtsRepository.GetForSelect();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = list
            };
        }
    }
}
