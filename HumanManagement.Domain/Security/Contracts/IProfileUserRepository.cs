using System.Threading.Tasks;
using System.Collections.Generic;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface IProfileUserRepository
    {
        Task<int> GetProfileByUser(int idUser);
        Task<List<int>> UpdateProfile(int profile, int user);
    }
}
