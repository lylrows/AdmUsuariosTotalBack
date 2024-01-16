using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{
    public class GetUserByTokenQuery : IRequest<UserSessionDto>
    {
        public string Token { get; set; }
        public class GetUserByTokenQueryHandler : IRequestHandler<GetUserByTokenQuery, UserSessionDto>
        {
            private readonly ITokenUserRepository tokenUserRepository;
            public GetUserByTokenQueryHandler(ITokenUserRepository tokenUserRepository)
            {
                this.tokenUserRepository = tokenUserRepository;
            }
            public async Task<UserSessionDto> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
            {
                return await tokenUserRepository.GetUserByToken(request.Token);
            }
        }
    }
}
