using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Security.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{
    public class GetListPerfilQuery : IRequest<Result>
    {

        public class GetListPerfilQueryHandler : IRequestHandler<GetListPerfilQuery, Result>
        {
            private readonly IBaseRepository<Profile> baseProfileRepository;
            public GetListPerfilQueryHandler(IBaseRepository<Profile> baseProfileRepository)
            {
                this.baseProfileRepository = baseProfileRepository;
            }
            public async Task<Result> Handle(GetListPerfilQuery request, CancellationToken cancellationToken)
            {
                var profileList = await baseProfileRepository.GetAll();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = profileList
                };
            }
        }
    }
}
