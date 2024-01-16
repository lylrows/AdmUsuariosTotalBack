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
    public class SkillsPostulantRepository : ISkillsPostulantRepository
    {
        private readonly DbContextMsSql context;

        public SkillsPostulantRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<SkillsPostulantDto>> GetSkillsByPostulant(int IdPersona)
        {
            var dto = await (from p in context.SkillsPostulant
                       where p.IdPerson == IdPersona && p.Active == true
                       select new SkillsPostulantDto
                       {
                           Id = p.Id,
                           DescriptionSkill = p.DescriptionSkill,
                           IdPerson = p.IdPerson
                       }).ToListAsync();
            return dto;
        }
    }
}
