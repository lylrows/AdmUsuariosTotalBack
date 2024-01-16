using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface ILoginAttemptRepository
    {
        Task<int> GetByIdUser(int idUser);
        Task UpdateAttempt(int id);
        Task<int> GetNumberAttempts(int id);
    }
}
