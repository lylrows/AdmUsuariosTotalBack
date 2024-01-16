using HumanManagement.Domain.Security.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface ITokenUserRepository
    {
        Task<bool> IsValidToken(TokenUserQueryDto tokenUserQueryDto);
        Task<int> GetIdTokenActiveByUser(int idUser);
        Task<UserSessionDto> GetUserByToken(string token);
    }
}
