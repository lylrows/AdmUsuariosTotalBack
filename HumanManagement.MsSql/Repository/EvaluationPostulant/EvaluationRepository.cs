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
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly DbContextMsSql context;
        public EvaluationRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<EvaluationQueryDto> GetEvaluation(int IdEvaluation)
        {
            var dto = await (from p in context.tb_evaluation_flu
                             join m in context.MasterTable on
                             p.State equals m.Id
                             join j in context.tb_Job on
                             p.IdJob equals j.Id_Job
                             where p.Id == IdEvaluation
                             select new EvaluationQueryDto
                             {
                                 Id = p.Id,
                                 Nidjob = p.IdJob,
                                 Id_Company = j.Id_Company,
                                 CodRequerimiento = p.CodRequerimiento,
                                 PositionRequired = p.PositionRequired,
                                 State = m.DescriptionValue,
                                 Process = p.Process
                                 
                             }).FirstOrDefaultAsync();
            return dto;
        }

        public async Task<List<EvaluationListDto>> GetEvaluationList(int IdJob)
        {
            var dto = await (from p in context.tb_evaluation_flu
                             join m in context.MasterTable on
                             p.State equals m.Id
                             where p.IdJob == IdJob
                             select new EvaluationListDto
                             {
                                 Id = p.Id,
                                 State = m.DescriptionValue,
                                 CodReq = p.CodRequerimiento,
                                 DateRegister = p.DateRegister,
                                 PositionRequired = p.PositionRequired
                             }).ToListAsync();
            return dto;
        }
    }
}
