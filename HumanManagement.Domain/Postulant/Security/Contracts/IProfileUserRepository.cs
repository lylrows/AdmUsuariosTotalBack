using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Security.Contracts
{ 
    public interface IProfileUserRepository
    {
        Task<int> GetProfileByUser(int idUser);
    }
}
