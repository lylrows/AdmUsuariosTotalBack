using HumanManagement.Domain.Postulant.Person.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Person.Contracts
{
    public interface IPersonSkillRepository
    {
        Task<List<PostulantSkillsDto>> GetListSkill(int[] arrayIdPostulant);
    }
}
