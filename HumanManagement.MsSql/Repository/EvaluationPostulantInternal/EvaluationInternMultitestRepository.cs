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
    public class EvaluationInternMultitestRepository : IEvaluationInternMultitestRepository
    {
        private readonly DbContextMsSql context;
        public EvaluationInternMultitestRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<EvaluationMultitestInternDto>> GetEvaluationMultitestIntern(int IdEvaluation)
        {
            var dto = await (from e in context.tb_evaluation_multitest_intern
                             join p in
context.Person on e.IdPostulant equals p.Id
                             where e.IdEvaluation == IdEvaluation
                             select new EvaluationMultitestInternDto
                             {
                                 Id = e.Id,
                                 IdEvaluation = e.IdEvaluation,
                                 IdPostulant = e.IdPostulant,
                                 Postulant = string.Concat(p.FirstName, " ", p.LastName),
                                 ScoreAptitudAbstracta = e.ScoreAptitudAbstracta,
                                 ScoreAptitudEspacial = e.ScoreAptitudEspacial,
                                 ScoreAptitudNumerica = e.ScoreAptitudNumerica,
                                 ScoreAptitudVerbal = e.ScoreAptitudVerbal,
                                 ScoreIntelligence = e.ScoreIntelligence
                             }).ToListAsync();
            return dto;
        }
    }
}
