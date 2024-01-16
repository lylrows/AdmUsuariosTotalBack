using HumanManagement.Domain.Postulant.Security.Models;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Security.Contracts
{
    public interface ITokenUserService
    {
        Task AddOrUpdate(TokenUserPostulant tokenUser);
    }
}
