using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.EvaluationPostulant
{
    public class EvaluationProficiencyRepository : IEvaluationProficiencyRepository
    {
        private readonly DbContextMsSql dbContext;
        public EvaluationProficiencyRepository(DbContextMsSql dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<EvaluationProficiencyDto>> GetEvaluationProficiencies(int IdEvaluation, int IdPostulant)
        {
            var dto = await (from e in dbContext.tb_evaluation_proficiency
                             join p in dbContext.PersonPostulant on e.IdPostulant equals p.Id
                             join pro in dbContext.tb_proficiency on e.IdProficiency equals pro.IdProficiency
                             where e.IdEvaluation == IdEvaluation && e.IdPostulant == IdPostulant
                             select new EvaluationProficiencyDto
                             {
                                 Id = e.Id,
                                 IdEvaluation = e.IdEvaluation,
                                 IdProficiency = e.IdProficiency,
                                 IdPostulant = e.IdPostulant,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 Proficiency = pro.NameProficiency,
                                 LevelClient = e.LevelClient,
                                 LevelJefe = e.LevelJefe,
                                 LevelRRHH = e.LevelRRHH,
                                 Expectative = e.Expectative,
                                 Required = pro.Required
                             }).ToListAsync();
            return dto;
        }

        public async Task<List<EvaluationProficiencyDto>> GetEvaluationProficiencies(int IdEvaluation)
        {
            var dto = await (from e in dbContext.tb_evaluation_proficiency
                             join p in dbContext.PersonPostulant on e.IdPostulant equals p.Id
                             join pro in dbContext.tb_proficiency on e.IdProficiency equals pro.IdProficiency
                             where e.IdEvaluation == IdEvaluation
                             select new EvaluationProficiencyDto
                             {
                                 Id = e.Id,
                                 IdEvaluation = e.IdEvaluation,
                                 IdProficiency = e.IdProficiency,
                                 IdPostulant = e.IdPostulant,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 Proficiency = pro.NameProficiency,
                                 LevelClient = e.LevelClient,
                                 LevelJefe = e.LevelJefe,
                                 LevelRRHH = e.LevelRRHH,
                                 Expectative = e.Expectative
                             }).ToListAsync();
            return dto;
        }
    }
}
