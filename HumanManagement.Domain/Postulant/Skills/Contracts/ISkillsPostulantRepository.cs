using HumanManagement.Domain.Postulant.Skills.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Skills.Contracts
{
    public interface ISkillsPostulantRepository
    {
        Task<List<SkillsPostulantDto>> GetSkillsByPostulant(int IdPersona);
    }
}
