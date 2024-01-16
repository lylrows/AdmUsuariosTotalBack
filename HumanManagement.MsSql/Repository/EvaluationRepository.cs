using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.Domain.Evaluation.Dto;
using HumanManagement.Domain.Evaluation.Models;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class EvaluationRepository : BaseRepository<Evaluation>,IEvaluationRepository
    {

        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public EvaluationRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context) : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<EvaluationHeaderDto> GetEvaluationById(int IdEvaluation)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidEvaluation", IdEvaluation);


            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationHeaderDto>(
                 "campaign.sps_evaluation_header",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }
       
        public async Task<List<EvaluationDetailDto>> GetListEvaluationDetail(int IdEvaluation)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidEvaluation", IdEvaluation);


            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationDetailDto>(
                 "campaign.sps_evaluation_detail",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }


        public async Task<List<EvaluationMailDto>> GetEvaluationsMail(int nIdCampaign)
        {
            var result = await (from eval in context.tb_evaluation
                                join emp  in context.Employee
                                on eval.IdEvaluated equals emp.Id
                                join pers in context.Person 
                                on  emp.IdPerson equals pers.Id
                                join camp in context.tb_campaign 
                                on eval.IdCampaign equals camp.Id_Campaign
                                join ch in context.tb_charge
                                on emp.IdPosition equals ch.Id
                                where eval.IdCampaign == nIdCampaign 
                                select new EvaluationMailDto
                                { 
                                    NameEvaluated = pers.FirstName,
                                    Email = pers.Email,
                                    IdEvaluation = eval.IdEvaluation,
                                    CampaignName = camp.NameCampaign,
                                    PersonId = pers.Id,
                                    AreaId = ch.IdArea
                                }).ToListAsync();

            return result;
        }

        public async Task<List<EvaluationHeaderDto>> GetEvaluationByIdCampaign(int IdCampaign)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", IdCampaign);


            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationHeaderDto>(
                 "campaign.sps_evaluation_header_byCampaign",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task DeleteEmployeeByCampaign(int IdEvaluation, string Comment, int EmployeeId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_evaluation", IdEvaluation);
            queryParameters.Add("@comment", Comment);
            queryParameters.Add("@employeeId", EmployeeId);

            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationDetailDto>(
                 "campaign.sp_delete_employee_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<PrintEvaluationHeaderDto> GetPrintEvaluationById(int IdEvaluation)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidEvaluation", IdEvaluation);


            var list = await humanManagementReadDbConnection.QueryAsync<PrintEvaluationHeaderDto>(
                 "campaign.sps_print_evaluation_header",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }
        

        public async Task<List<EvaluationDetailObjetivosDto>> GetListEvaluationDetailObjetivos(int IdEvaluation)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidEvaluation", IdEvaluation);


            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationDetailObjetivosDto>(
                 "campaign.sps_print_evaluation_detail_objetives",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<EvaluationDetailCompentenciasDto>> GetListEvaluationDetailCompetencias(int IdEvaluation)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidEvaluation", IdEvaluation);


            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationDetailCompentenciasDto>(
                 "campaign.sps_print_evaluation_detail_competencies",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<EvaluationDetailComentariosDto>> GetListEvaluationDetailComentarios(int IdEvaluation)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidEvaluation", IdEvaluation);


            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationDetailComentariosDto>(
                 "campaign.sps_print_evaluation_detail_comments",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }
        
    }
}
