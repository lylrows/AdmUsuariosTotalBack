using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Dto;
using SitePostulant.Application.Security.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Security.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenUserRepository tokenRepository;

        public TokenService(ITokenUserRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }
        public async Task<UserSessionDto> GetUserByToken(string token)
        {
            return await tokenRepository.GetUserByToken(token);

        }

        public async Task<bool> IsValidToken(TokenUserQueryDto tokenUserQueryDto)
        {
            return await tokenRepository.IsValidToken(tokenUserQueryDto);
        }
    }
}
