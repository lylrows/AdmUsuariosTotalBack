using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Contracts;
using System.Data;
using Dapper;
using HumanManagement.Domain.Common;

namespace HumanManagement.MsSql.Repository.Postulant.Person
{
    public class PersonSkillRepository : IPersonSkillRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public PersonSkillRepository(DbContextMsSql context,
                                     IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
        }
        public async Task<List<PostulantSkillsDto>> GetListSkill(int[] arrayIdPostulant)
        {
            var list = await (from n in context.SkillsPostulant
                              where arrayIdPostulant.Contains(n.IdPerson) && n.Active == true
                              select new PostulantSkillsDto
                              {
                                  IdPostulant = n.IdPerson,
                                  Skill = n.DescriptionSkill
                              }).ToListAsync();

            return list;
        }
    }
}
