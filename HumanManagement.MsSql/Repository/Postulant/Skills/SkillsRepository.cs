using HumanManagement.Domain.Postulant.Skills.Contracts;
using HumanManagement.Domain.Postulant.Skills.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.Postulant.Skills
{
    public class SkillsRepository: ISkillsRepository
    {
        private readonly DbContextMsSql context;
        public SkillsRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task<List<SkillsDto>> GetSkillsSearch(string description)
        {
            var dto = await (from p in context.Skills
                             where p.Name.Contains(description.Trim())
                             select new SkillsDto
                             {
                                 DescriptionSkill = p.DescriptionSkill
                             }).ToListAsync();
            return dto;
        }
    }
}
