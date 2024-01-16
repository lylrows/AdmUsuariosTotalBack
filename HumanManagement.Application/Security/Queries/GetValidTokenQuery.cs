using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{
    public class GetValidTokenQuery : IRequest<bool>
    {
        public TokenUserQueryDto TokenUserQuery { get; set; }

        public class GetValidTokenQueryHandler : IRequestHandler<GetValidTokenQuery, bool>
        {
            private readonly ITokenUserRepository tokenUserRepository;
            public GetValidTokenQueryHandler(ITokenUserRepository tokenUserRepository)
            {
                this.tokenUserRepository = tokenUserRepository;
            }
            public async Task<bool> Handle(GetValidTokenQuery request, CancellationToken cancellationToken)
            {
                var isValidToken = await tokenUserRepository.IsValidToken(request.TokenUserQuery);

                return isValidToken;
            }
        }
    }
}
