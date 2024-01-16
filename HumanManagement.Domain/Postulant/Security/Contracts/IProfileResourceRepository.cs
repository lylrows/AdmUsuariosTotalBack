using HumanManagement.Domain.Security.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Security.Contracts
{
    public interface IProfileResourceRepository
    {
        Task<List<ProfileResourceDto>> GetListResource(int idProfile);
    }
}
