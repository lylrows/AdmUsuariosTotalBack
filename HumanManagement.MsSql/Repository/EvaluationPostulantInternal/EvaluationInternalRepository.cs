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
    public class EvaluationInternalRepository : IEvaluationInternalRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementDbContext connetion;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;

        public EvaluationInternalRepository(DbContextMsSql context, IHumanManagementDbContext connetion, IHumanManagementReadDbConnection humanManagementReadDbConnection) 
        {
            this.context = context;
            this.connetion = connetion;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<EvaluationQueryDto> GetEvaluation(int IdEvaluation)
        {
            var dto = await (from p in context.tb_evaluation_vacant_internal
                             join m in context.MasterTable on
                             p.State equals m.Id
                             where p.Id == IdEvaluation
                             select new EvaluationQueryDto
                             {
                                 Id = p.Id,
                                 CodRequerimiento = p.CodRequerimiento,
                                 PositionRequired = p.PositionRequired,
                                 State = m.DescriptionValue,
                                 Process = p.Process
                             }).FirstOrDefaultAsync();
            return dto;
        }

        public async Task<List<EvaluationInternListDto>> GetEvaluationList(int IdJob)
        {
            var dto = await (from p in context.tb_evaluation_vacant_internal
                             join m in context.MasterTable on
                             p.State equals m.Id
                             where p.IdJob == IdJob
                             select new EvaluationInternListDto
                             {
                                 Id = p.Id,
                                 State = m.DescriptionValue,
                                 CodReq = p.CodRequerimiento,
                                 DateRegister = p.DateRegister,
                                 PositionRequired = p.PositionRequired
                             }).ToListAsync();
            return dto;
        }

        public async Task<bool> DeletePositionPostulant(int IdEvaluationPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_evaluation_postulant", IdEvaluationPostulant);
            var result = await connetion.Connection.ExecuteAsync(
                 "sp_delete_positions_postulant",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return true;
        }

        public async Task<bool> InsertPositionPostulant(PositionCompany positionCompany)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_evaluation_postulant", positionCompany.IdEvaluationPostulant);
                queryParameters.Add("@scharge", positionCompany.scharge);
                queryParameters.Add("@nmonth_init", positionCompany.monthInit);
                queryParameters.Add("@nyear_init", positionCompany.yearInit);
                queryParameters.Add("@nmonth_end", positionCompany.monthEnd);
                queryParameters.Add("@nyear_end", positionCompany.yearEnd);
                queryParameters.Add("@speriod_start", positionCompany.pstart);
                queryParameters.Add("@speriod_end", positionCompany.pend);
                queryParameters.Add("@nmonths", positionCompany.months);
                queryParameters.Add("@nuser", positionCompany.nuser);
                var result = await connetion.Connection.ExecuteAsync(
                     "sp_insert_positions_postulant",
                     queryParameters, null, null, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                var error = ex;
            }

            return true;
        }

        public async Task<List<PositionCompany>> GetPositionPostulant(int IdEvaluationPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_evaluation_postulant", IdEvaluationPostulant);
            var listposition = await humanManagementReadDbConnection.QueryAsync<PositionCompany>(
                 "sp_positions_by_postulant",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listposition.ToList();
        }
    }
}
