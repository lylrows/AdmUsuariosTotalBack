using System.Threading.Tasks;

namespace HumanManagement.Domain.Person.Contracts
{
    public interface IPhoneRepository
    {
        Task DeleteByPerson(int idPerson);
    }
}
