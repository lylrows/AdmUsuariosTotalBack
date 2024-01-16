using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.EvaluationPostulantInternal
{
    public class EvaluationProficiencyInternRepository: IEvaluationProficiencyInternRepository
    {
        private readonly DbContextMsSql contexto;
        public EvaluationProficiencyInternRepository(DbContextMsSql contexto)
        {
            this.contexto = contexto;
        }

        public async Task<List<EvaluationProficiencyInternDto>> GetEvaluationProficiencies(int IdEvaluation, int IdPostulant, int Flag)
        {
            var dto = await (from e in contexto.tb_evaluation_proficiency_intern
                             join p in contexto.Person on e.IdPostulant equals p.Id
                             join pro in contexto.tb_proficiency on e.IdProficiency equals pro.IdProficiency
                             where e.IdEvaluation == IdEvaluation && e.IdPostulant == IdPostulant && e.Flag == Flag
                             select new EvaluationProficiencyInternDto
                             {
                                 Id = e.Id,
                                 IdEvaluation = e.IdEvaluation,
                                 IdProficiency = e.IdProficiency,
                                 IdPostulant = e.IdPostulant,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 Proficiency = pro.NameProficiency,
                                 LevelJefe = e.LevelJefe,
                                 TestRRHH = e.testRRHH,
                                 ComentarioRRHH = e.comentarioRRHH,
                                 LevelRRHH = e.LevelRRHH,
                                 Flag = e.Flag,
                                 Expectative = e.Expectative,
                                 required = pro.Required
                             }).ToListAsync();
            return dto;
        }

        public async Task<List<EvaluationProficiencyInternDto>> GetEvaluationProficiencies(int IdEvaluation, int Flag)
        {
            var dto = await (from e in contexto.tb_evaluation_proficiency_intern
                             join p in contexto.Person on e.IdPostulant equals p.Id
                             join pro in contexto.tb_proficiency on e.IdProficiency equals pro.IdProficiency
                             where e.IdEvaluation == IdEvaluation  && e.Flag == Flag
                             select new EvaluationProficiencyInternDto
                             {
                                 Id = e.Id,
                                 IdEvaluation = e.IdEvaluation,
                                 IdProficiency = e.IdProficiency,
                                 IdPostulant = e.IdPostulant,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 Proficiency = pro.NameProficiency,
                                 LevelJefe = e.LevelJefe,
                                 LevelRRHH = e.LevelRRHH,
                                 Flag = e.Flag,
                                 Expectative = e.Expectative
                             }).ToListAsync();
            return dto;
        }
    }
}
