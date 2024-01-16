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
    public class EvaluationFortalezasInternRepository : IEvaluationFortalezasInternRepository
    {
        private readonly DbContextMsSql context;
        public EvaluationFortalezasInternRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<EvaluationFortalezasInternDto>> GetEvaluationFortalezasPostulants(int IdEvaluation, int IdPostulant)
        {
            var dto = await (from r in context.tb_evaluation_fortalezas_intern
                             join p in context.Person
                             on r.IdPostulant equals p.Id
                             where r.IdEvaluation == IdEvaluation && r.IdPostulant == IdPostulant
                             select new EvaluationFortalezasInternDto
                             {
                                 Id = r.Id,
                                 IdPostulant = r.IdPostulant,
                                 IdEvaluation = r.IdEvaluation,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 SRatingjefeopportunities = r.SRatingjefeopportunities,
                                 SRatingjefestrengths = r.SRatingjefestrengths,
                                 SRatingrrhhopportunities = r.SRatingrrhhopportunities,
                                 SRatingrrhhstrengths = r.SRatingrrhhstrengths
                             }).ToListAsync();
            return dto;
        }

        public async Task<List<EvaluationFortalezasInternDto>> GetEvaluationFortalezasPostulants(int IdEvaluation)
        {
            var dto = await (from r in context.tb_evaluation_fortalezas_intern
                             join p in context.Person
                             on r.IdPostulant equals p.Id
                             where r.IdEvaluation == IdEvaluation
                             select new EvaluationFortalezasInternDto
                             {
                                 Id = r.Id,
                                 IdPostulant = r.IdPostulant,
                                 IdEvaluation = r.IdEvaluation,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 SRatingjefeopportunities = r.SRatingjefeopportunities,
                                 SRatingjefestrengths = r.SRatingjefestrengths,
                                 SRatingrrhhopportunities = r.SRatingrrhhopportunities,
                                 SRatingrrhhstrengths = r.SRatingrrhhstrengths
                             }).ToListAsync();
            return dto;
        }
    }
}
