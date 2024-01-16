using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface ILoginAttemptService
    {
        Task AddAttempt(string userName);
    }
}
