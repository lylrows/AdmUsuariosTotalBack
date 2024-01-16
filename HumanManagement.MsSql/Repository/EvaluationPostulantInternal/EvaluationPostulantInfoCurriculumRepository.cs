using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Contracts;
using Dapper;
using System.Data;

namespace HumanManagement.MsSql.Repository.EvaluationPostulantInternal
{
    public class EvaluationPostulantInfoCurriculumRepository : IEvaluationPostulantInfoCurriculumRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementDbContext connetion;

        public EvaluationPostulantInfoCurriculumRepository(DbContextMsSql context, IHumanManagementDbContext connetion)
        {
            this.context = context;
            this.connetion = connetion;
        }
        public async Task<List<EvaluationPostulantInfoCurriculumDto>> GetList(int IdEvaluation)
        {
            var dto = await (from p in context.tb_evaluation_postulant_info_curriculum
                             join m in context.MasterTable on p.IdDetail equals m.Id
                             where p.IdEvaluationPostulant == IdEvaluation
                             select new EvaluationPostulantInfoCurriculumDto
                             {
                                 Id = p.Id,
                                 Comments = p.Comments,
                                 IdDetail = p.IdDetail,
                                 Detail = m.DescriptionValue,
                                 Espectative = p.Espectative,
                                 IdEvaluationPostulant = p.IdEvaluationPostulant,
                                 IdValidation = p.IdValidation
                             }).ToListAsync();

            return dto;
        }

        public async Task<bool> SetDataInitial(int IdEvaluationPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_evaluation_postulant", IdEvaluationPostulant);
            var result = await connetion.Connection.ExecuteAsync(
                 "spu_data_initial_expectatives_postulant",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return true;
        }
    }
}
