using HumanManagement.Domain.Postulant.Area.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Area.Contracts
{
    public interface IRecruitmentAreaRepository
    {
        Task<List<AreaForSelectDto>> GetForSelect();
    }
}
