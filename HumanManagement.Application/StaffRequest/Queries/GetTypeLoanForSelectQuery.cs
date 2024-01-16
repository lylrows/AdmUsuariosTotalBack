using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetTypeLoanForSelectQuery : IRequest<Result>
    {
    }
    public class GetTypeLoanForSelectQueryHandler : IRequestHandler<GetTypeLoanForSelectQuery, Result>
    {
        private readonly ITypeLoanRepository typeLoanRepository;
        public GetTypeLoanForSelectQueryHandler(ITypeLoanRepository typeLoanRepository)
        {
            this.typeLoanRepository = typeLoanRepository;
        }
        public async Task<Result> Handle(GetTypeLoanForSelectQuery request, CancellationToken cancellationToken)
        {
            var list = await typeLoanRepository.GetForSelect();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = list
            };
        }
    }
}
