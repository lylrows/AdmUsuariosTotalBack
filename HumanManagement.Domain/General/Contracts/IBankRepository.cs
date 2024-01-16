using System.Threading.Tasks;

namespace HumanManagement.Domain.General.Contracts
{
    public interface IBankRepository
    {
        Task<int> GetIdByCode(string codeBank);
    }
}
