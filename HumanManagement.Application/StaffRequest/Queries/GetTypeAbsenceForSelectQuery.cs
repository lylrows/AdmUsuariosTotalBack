using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetTypeAbsenceForSelectQuery : IRequest<Result>
    {

    }
    public class GetTypeAbsenceForSelectQueryHandler : IRequestHandler<GetTypeAbsenceForSelectQuery, Result>
    {
        private readonly ITypeAbsenceRepository typeAbsenceRepository;
        public GetTypeAbsenceForSelectQueryHandler(ITypeAbsenceRepository typeAbsenceRepository)
        {
            this.typeAbsenceRepository = typeAbsenceRepository;
        }
        public async Task<Result> Handle(GetTypeAbsenceForSelectQuery request, CancellationToken cancellationToken)
        {
            var list = await typeAbsenceRepository.GetForSelect();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = list
            };
        }
    }
}
