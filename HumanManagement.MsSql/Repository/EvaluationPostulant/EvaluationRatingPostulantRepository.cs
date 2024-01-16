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
    public class EvaluationRatingPostulantRepository : IEvaluationRatingRepository
    {
        private readonly DbContextMsSql dbContext;
        public EvaluationRatingPostulantRepository(DbContextMsSql dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<EvaluationRatingPostulantDto>> GetEvaluationRatingPostulants(int IdEvaluation, int IdPostulant)
        {
            var dto = await (from r in dbContext.tb_evaluation_rating
                             join p in dbContext.PersonPostulant
                             on r.IdPostulant equals p.Id
                             where r.IdEvaluation == IdEvaluation && r.IdPostulant == IdPostulant
                             select new EvaluationRatingPostulantDto
                             {
                                 Id = r.Id,
                                 IdPostulant = r.IdPostulant,
                                 IdEvaluation = r.IdEvaluation,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 SRatingjefeopportunities = r.SRatingjefeopportunities,
                                 SRatingjefestrengths = r.SRatingjefestrengths,
                                 SRatingrrhhopportunities = r.SRatingrrhhopportunities,
                                 SRatingrrhhstrengths = r.SRatingrrhhstrengths,
                                 SRatingclientopportunities = r.SRatingclientopportunities,
                                 SRatingclientstrengths = r.SRatingclientstrengths
                             }).ToListAsync();
            return dto;
        }

        public async Task<List<EvaluationRatingPostulantDto>> GetEvaluationRatingPostulants(int IdEvaluation)
        {
            var dto = await (from r in dbContext.tb_evaluation_rating
                             join p in dbContext.PersonPostulant
                             on r.IdPostulant equals p.Id
                             where r.IdEvaluation == IdEvaluation
                             select new EvaluationRatingPostulantDto
                             {
                                 Id = r.Id,
                                 IdPostulant = r.IdPostulant,
                                 IdEvaluation = r.IdEvaluation,
                                 FullNamePostulant = string.Concat(p.FirstName, " ", p.LastName),
                                 SRatingjefeopportunities = r.SRatingjefeopportunities,
                                 SRatingjefestrengths = r.SRatingjefestrengths,
                                 SRatingrrhhopportunities = r.SRatingrrhhopportunities,
                                 SRatingrrhhstrengths = r.SRatingrrhhstrengths,
                                 SRatingclientopportunities = r.SRatingclientopportunities,
                                 SRatingclientstrengths = r.SRatingclientstrengths
                             }).ToListAsync();
            return dto;
        }
    }
}
