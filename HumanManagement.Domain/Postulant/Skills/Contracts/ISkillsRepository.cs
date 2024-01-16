using HumanManagement.Domain.Postulant.Skills.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Skills.Contracts
{
    public interface ISkillsRepository
    {
        Task<List<SkillsDto>> GetSkillsSearch(string description);
    }
}
