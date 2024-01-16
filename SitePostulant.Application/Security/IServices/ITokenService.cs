using HumanManagement.Domain.Postulant.Security.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Security.IServices
{
    public interface ITokenService
    {
        Task<UserSessionDto> GetUserByToken(string token);
        Task<bool> IsValidToken(TokenUserQueryDto tokenUserQueryDto);
    }
}
