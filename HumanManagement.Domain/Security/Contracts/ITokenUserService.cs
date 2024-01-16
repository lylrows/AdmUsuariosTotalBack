using HumanManagement.Domain.Security.Models;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface ITokenUserService
    {
        Task AddOrUpdate(TokenUser tokenUser);
    }
}
