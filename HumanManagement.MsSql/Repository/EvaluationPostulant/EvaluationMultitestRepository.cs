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
    public class EvaluationMultitestRepository : IEvaluationMultitestRepository
    {
        private readonly DbContextMsSql context;
        public EvaluationMultitestRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<EvaluationMultitestExternDto>> GetEvaluationMultitest(int IdEvaluation)
        {
            var dto = await (from e in context.tb_evaluation_multitest_extern
                             join p in
context.PersonPostulant on e.IdPostulant equals p.Id
                             where e.IdEvaluation == IdEvaluation
                             select new EvaluationMultitestExternDto
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
