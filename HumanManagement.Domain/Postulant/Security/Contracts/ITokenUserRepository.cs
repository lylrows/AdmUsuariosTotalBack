using HumanManagement.Domain.Postulant.Security.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Security.Contracts
{ 
    public interface ITokenUserRepository
    {
        Task<bool> IsValidToken(TokenUserQueryDto tokenUserQueryDto);
        Task<int> GetIdTokenActiveByUser(int idUser);
        Task<int> GetIdUserByToken(string token);
        Task<UserSessionDto> GetUserByToken(string token);
    }
}
