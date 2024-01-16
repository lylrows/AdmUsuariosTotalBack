using Dapper;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Campaign.Models;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
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
    public class CampaignRepository : BaseRepository<Campaign>, ICampaignRepository
    {

        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public CampaignRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<ResultPaginationListDto<CampaignListDto>> GetListUsersPagination(CampaignQueryFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@ncurrentpage", filter.CurrentPage);
            queryParameters.Add("@nitemsperPage", filter.ItemsPerPage);


            queryParameters.Add("@nidCampana", filter.nidCampana);
            queryParameters.Add("@snamecampaign", filter.snamecampaign??"");
            queryParameters.Add("@nstatus", filter.nstatus);
            queryParameters.Add("@nyear", filter.nyear);
            queryParameters.Add("@nmonth", filter.nmonth);



            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var list = await humanManagementReadDbConnection.QueryAsync<CampaignListDto>(
                 "campaign.sps_campaign_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<CampaignListDto> result = new ResultPaginationListDto<CampaignListDto>();
            result.list = list.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.ItemsPerPage);

            return result;
        }

        public async Task<ResultPaginationListDto<EmployeeByCampaignListDto>> GetEmployeeByCampaign(EmployeeByCampaignFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@ncurrentpage", filter.CurrentPage);
            queryParameters.Add("@nitemsperPage", filter.ItemsPerPage);


            queryParameters.Add("@sdni", filter.Dni??"");
            queryParameters.Add("@sname", filter.Name??"");
            queryParameters.Add("@nposition", filter.Position);

            queryParameters.Add("@nidCampana", filter.nidCampana);
            queryParameters.Add("@nidcompany", filter.nidcompany);
            queryParameters.Add("@nidgerencia", filter.nidgerencia);
            queryParameters.Add("@nidArea", filter.nidArea);
            queryParameters.Add("@nidsubarea", filter.nidsubarea);
            queryParameters.Add("@nflagSearch", filter.nflagSearch);

            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var list = await humanManagementReadDbConnection.QueryAsync<EmployeeByCampaignListDto>(
                 "campaign.sps_employeebycampaign",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<EmployeeByCampaignListDto> result = new ResultPaginationListDto<EmployeeByCampaignListDto>();
            result.list = list.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.ItemsPerPage);

            return result;
        }

        public async Task<CampaignEmployee> FindCampaignEmployee(int nIdCampaign, int nIdEmployee)
        {
            var result = await (from pers in context.tb_campaign_employee
                                where pers. IdCampaign == nIdCampaign && pers.IdEmployee == nIdEmployee
                                select pers).SingleOrDefaultAsync();

            return result;
        }
        public async Task<CampaignDto> FindCampaignById(int nIdCampaign)
        {
            var result = await (from pers in context.tb_campaign
                                where pers.Id_Campaign == nIdCampaign
                                select new CampaignDto
                                {
                                    Id_Campaign = pers.Id_Campaign,
                                    StartDate = pers.StartDate == null ? "" : pers.StartDate.Value.ToShortDateString(),
                                    EndDate = pers.EndDate == null ? "" : pers.EndDate.Value.ToShortDateString(),
                                    Year = pers.Year,
                                    Month = pers.Month,
                                    NameCampaign = pers.NameCampaign,
                                    CantidadColaboradores = context.tb_campaign_employee.Where(i=>i.IdCampaign == nIdCampaign && i.Active).Count(),
                                    StatusName = (
                                                    pers.Status == 1 ? "Creado" :
                                                    pers.Status == 2 ? "Lanzado":
                                                    pers.Status == 3 ? "Reiniciado": "Otro"
                                                  ),
                                    IsEvaluationGenerated= pers.IsEvaluationGenerated
                                }).SingleOrDefaultAsync();
            return result;
        }
        /// <summary>
        /// Metodo que retorna las competencias disponibles y las asignadas por puesto  ( durante una campaña ) 
        /// </summary>
        /// <param name="nIdCampaign"></param>
        /// <param name="nIdCharge"></param>
        /// <param name="nFlagSearch"></param>
        /// <returns></returns>
        public async Task<List<ProficiencyByChargeListDto>> GetProficiencyByCharge(ProficiencyByChargeFilterDto filter)
        {
            var queryParameters = new DynamicParameters();
        
            queryParameters.Add("@nidCampana",  filter.nIdCampaign);
            queryParameters.Add("@nidCharge",   filter.nIdCharge);
            queryParameters.Add("@nflagSearch", filter.nFlagSearch);
        
            var list = await humanManagementReadDbConnection.QueryAsync<ProficiencyByChargeListDto>(
                 "campaign.sps_proficiencybycharge",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<ProficiencyCharge> FindProficiencyCharge(int nIdCampaign, int nIdcharge,int nIdProficiency)
        {
            var result = await (from pers in context.tb_proficiency_charge
                                where pers.IdCampaign == nIdCampaign && pers.IdCharge == nIdcharge && pers.IdProficiency == nIdProficiency
                                select pers).SingleOrDefaultAsync();

            return result;
        }

        public async Task<List<ProficiencyCharge>> ListProficienciesByCampaign(int nIdCampaign)
        {
            var result = await (from pers in context.tb_proficiency_charge
                                where pers.IdCampaign == nIdCampaign
                                && pers.Active
                                select pers).ToListAsync();

            return result;
        }
        public async Task<List<ProficienciesByCampaignDto>> ListProficienciesByCampaignDto(int nIdCampaign)
        {
            var result = await (from pers in context.tb_proficiency_charge
                                join pro in context.tb_proficiency 
                                on pers.IdProficiency equals  pro.IdProficiency
                                where pers.IdCampaign == nIdCampaign
                                && pers.Active
                                select new ProficienciesByCampaignDto()
                                {
                                    IdCampaign = pers.IdCampaign,
                                    IdCharge = pers.IdCharge,
                                    IdProficiency = pers.IdProficiency,
                                    Level= pers.Level,
                                    Weight   = pers.Weight,
                                    NameProficiency = pro.NameProficiency
                                }).ToListAsync();

            return result;
        }

        


        public async Task<int> GenerateEvaluations(int nIdCampaign)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;

            queryParameters.Add("@nidCampaign", nIdCampaign);
            queryParameters.Add("@nresult", DbType.Int32, direction: ParameterDirection.Output);
            

            var list = await humanManagementReadDbConnection.QueryAsync<ProficiencyByChargeListDto>(
                 "campaign.spi_generate_evaluations",
                 queryParameters, commandType: CommandType.StoredProcedure);
            result = Convert.ToInt32(queryParameters.Get<int>("@nresult"));


            return result;
        }


        public async Task<ResultPaginationListDto<EvaluationListDto>> GetListEvaluationsPagination(EvaluationQueryFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@ncurrentpage", filter.CurrentPage);
            queryParameters.Add("@nitemsperPage", filter.ItemsPerPage);
            queryParameters.Add("@nidcompany", filter.CompanyId);
            queryParameters.Add("@nidgerencia", filter.GerenciaId);
            queryParameters.Add("@nidarea", filter.AreaId);
            queryParameters.Add("@nidsubarea", filter.SubAreaId);

            queryParameters.Add("@nidCampana", filter.nidCampana);
            queryParameters.Add("@number_action", filter.numberAction); 
            queryParameters.Add("@statusetapa", filter.statusEtapa);

            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationListDto>(
                 "campaign.sps_evaluation_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<EvaluationListDto> result = new ResultPaginationListDto<EvaluationListDto>();
            result.list = list.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.ItemsPerPage);

            return result;
        }        
        public async Task<ResultPaginationListDto<EvaluationListDto>> GetListEvaluationsPaginationDeleted(EvaluationQueryFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", filter.CompanyId);

            queryParameters.Add("@nidCampana", filter.nidCampana);

            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationListDto>(
                 "campaign.sps_deleted_employee_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<EvaluationListDto> result = new ResultPaginationListDto<EvaluationListDto>();
            result.list = list.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.ItemsPerPage);

            return result;
        }


        public async Task<List<EvaluationListDto>> GetMyEvaluation(MyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampana);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@flat", filter.flat);

            queryParameters.Add("@nid_profile", filter.nid_profile);
            queryParameters.Add("@nid_position", filter.nid_position);
            queryParameters.Add("@companyid", filter.companyid);
            queryParameters.Add("@areaid", filter.areaid);

            queryParameters.Add("@list_employee", filter.list_employee);
            queryParameters.Add("@etapa", filter.etapa);

            var list = await humanManagementReadDbConnection.QueryAsync<EvaluationListDto>(
                 "campaign.sp_get_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);



            return list.ToList();
        }
        
        public async Task<ResultPaginationListDto<EvaluationListDto>> GetMyEvaluation_Paginated(MyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nyear", filter.nyear);
            queryParameters.Add("@nid_campaign", filter.nidCampana);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@flat", filter.flat);

            queryParameters.Add("@nid_profile", filter.nid_profile);
            queryParameters.Add("@nid_position", filter.nid_position);
            queryParameters.Add("@nidcompany", filter.companyid);
            queryParameters.Add("@nidgerencia", filter.gerenciaid);
            queryParameters.Add("@nidarea", filter.areaid);
            queryParameters.Add("@nidsubarea", filter.subareaid);
            
            queryParameters.Add("@list_employee", filter.list_employee);
            queryParameters.Add("@etapa", filter.etapa);
            queryParameters.Add("@statusetapa", filter.statusetapa);
            
            queryParameters.Add("@ncurrentpage",filter. currentPage);
            queryParameters.Add("@nitemsperPage",filter. itemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<EvaluationListDto>(
                 "campaign.sp_get_my_evaluation_paginated",
                 queryParameters, commandType: CommandType.StoredProcedure);

            ResultPaginationListDto<EvaluationListDto> result = new ResultPaginationListDto<EvaluationListDto>();
            result.list = listMyEvaluation.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.itemsPerPage);



            return result;
        }
        public async Task<ResultPaginationListDto<EvaluationListDto>> GetMyTeamEvaluation_Paginated(MyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampana);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@flat", filter.flat);

            queryParameters.Add("@nid_profile", filter.nid_profile);
            queryParameters.Add("@nid_position", filter.nid_position);
            queryParameters.Add("@companyid", filter.companyid);
            queryParameters.Add("@gerenciaid", filter.gerenciaid);
            queryParameters.Add("@areaid", filter.areaid);
            queryParameters.Add("@subareaid", filter.subareaid);

            queryParameters.Add("@list_employee", filter.list_employee);
            queryParameters.Add("@etapa", filter.etapa);

            queryParameters.Add("@ncurrentpage", filter.currentPage);
            queryParameters.Add("@nitemsperPage", filter.itemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<EvaluationListDto>(
                 "campaign.sp_get_my_teamevaluations",
                 queryParameters, commandType: CommandType.StoredProcedure);

            ResultPaginationListDto<EvaluationListDto> result = new ResultPaginationListDto<EvaluationListDto>();
            result.list = listMyEvaluation.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.itemsPerPage);



            return result;
        }

        public async Task<int> LaunchEvaluations(int nIdCampaign)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;

            queryParameters.Add("@nidCampaign", nIdCampaign);
            queryParameters.Add("@nresult", DbType.Int32, direction: ParameterDirection.Output);


            var list = await humanManagementReadDbConnection.QueryAsync<ProficiencyByChargeListDto>(
                 "campaign.spi_launchcampaign",
                 queryParameters, commandType: CommandType.StoredProcedure);
            result = Convert.ToInt32(queryParameters.Get<int>("@nresult"));


            return result;
        }

        public async Task<CampaignCountDto> GetCampaignCount(int IdCampaign)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidCampana", IdCampaign);


            var list = await humanManagementReadDbConnection.QueryAsync<CampaignCountDto>(
                 "campaign.sps_campaign_count",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<LastCampaignByEmployee> LastCampaignByEmployee(int nidemployee)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_employee", nidemployee);


            var list = await humanManagementReadDbConnection.QueryAsync<LastCampaignByEmployee>(
                 "campaign.sp_campaign_maxbyemployee",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<List<GetCampaingBorrador>> ListCampaingBorrador(int nidemployee)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_employee", nidemployee);


            var list = await humanManagementReadDbConnection.QueryAsync<GetCampaingBorrador>(
                 "campaign.sp_getcampaingalert",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }
        public async Task<List<NineBoxSPDto>> GetNineBox(NineBoxFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", filter.nidcompany);
            queryParameters.Add("@nidgerencia", filter.nidgerencia);
            queryParameters.Add("@nidarea", filter.nidarea);
            queryParameters.Add("@nidsubarea", filter.nidsubarea);
            queryParameters.Add("@nidcargo", filter.nidcargo);
            queryParameters.Add("@nidcampana", filter.nidcampana);
            //queryParameters.Add("@list_conceptos", filter.list_conceptos);


            var list = await humanManagementReadDbConnection.QueryAsync<NineBoxSPDto>(
                 "campaign.sps_ninebox",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<CampaingEvaluationListDto>> GetCampaingEvaluationAlert(int nidemployee)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_employee", nidemployee);

            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<CampaingEvaluationListDto>(
                 "campaign.sp_get_campaing_evaluation_alert",
                 queryParameters, commandType: CommandType.StoredProcedure);
                
            return listMyEvaluation.ToList();
        }

        public async Task<List<CampaingByUserMyEvaluationDto>> GetCampaingByUserMyEvaluation(CampaingByUserMyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nyear", filter.nyear);
            queryParameters.Add("@nid_campaign", filter.nidCampaing);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@companyid", filter.nidCompany);
            queryParameters.Add("@etapa", filter.etapa);



            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<CampaingByUserMyEvaluationDto>(
                 "campaign.sp_get_campaing_by_user_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listMyEvaluation.ToList();
        }
        

        public async Task<List<CompanyByCampaingUserMyEvaluationDto>> GetCompanyByCampaingUserMyEvaluation(CompanyByCampaingUserMyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampaing);
            queryParameters.Add("@nid_employee", filter.nidEmployee);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<CompanyByCampaingUserMyEvaluationDto>(
                 "campaign.sp_get_company_by_campaing_user_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listMyEvaluation.ToList();
        }

        public async Task<List<GerenciasByCampaingUserMyEvaluationDto>> GetGerenciasByCampaingUserMyEvaluation(GerenciasByCampaingUserMyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampaing);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@nid_company", filter.nidCompany);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<GerenciasByCampaingUserMyEvaluationDto>(
                 "campaign.sp_get_gerencias_by_campaing_user_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listMyEvaluation.ToList();
        }

        public async Task<List<AreasByCampaingUserMyEvaluationDto>> GetAreasByCampaingUserMyEvaluation(AreasByCampaingUserMyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampaing);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@nid_company", filter.nidCompany);
            queryParameters.Add("@nid_gerencia", filter.nidGerencia);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<AreasByCampaingUserMyEvaluationDto>(
                 "campaign.sp_get_areas_by_campaing_user_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listMyEvaluation.ToList();
        }

        public async Task<List<SubAreasByCampaingUserMyEvaluationDto>> GetSubAreasByCampaingUserMyEvaluation(SubAreasByCampaingUserMyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampaing);
            queryParameters.Add("@nid_employee", filter.nidEmployee);
            queryParameters.Add("@nid_company", filter.nidCompany);
            queryParameters.Add("@nid_gerencia", filter.nidGerencia);
            queryParameters.Add("@nid_area", filter.nidArea);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<SubAreasByCampaingUserMyEvaluationDto>(
                 "campaign.sp_get_subareas_by_campaing_user_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listMyEvaluation.ToList();
        }

        public async Task<List<CollaboratorsByCampaingUserMyEvaluationDto>> GetCollaboratosByCampaingUserMyEvaluation(CollaboratorsByCampaingUserMyEvaluationFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_campaign", filter.nidCampaing);
            queryParameters.Add("@nid_employee", filter.nidEmployee);


            var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<CollaboratorsByCampaingUserMyEvaluationDto>(
                 "campaign.sp_get_collaborators_by_campaing_user_my_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listMyEvaluation.ToList();
        }

        public async Task<List<CampaingByEvaluationDto>> GetCampaingByEvaluation()
        {

            var listCampaing = await humanManagementReadDbConnection.QueryAsync<CampaingByEvaluationDto>(
                 "campaign.sps_get_campaing_by_evaluation",
                 null, commandType: CommandType.StoredProcedure);

            return listCampaing.ToList();
        }

        public async Task<int> RegisterDetailCampaingLevelNineBox(int nIdCampaign)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;

            queryParameters.Add("@nid_campaign", nIdCampaign);
            queryParameters.Add("@nresult", DbType.Int32, direction: ParameterDirection.Output);


           var res= await humanManagementReadDbConnection.QueryAsync<ProficiencyByChargeListDto>(
                 "campaign.spi_register_campaign_detail_level_ninebox",
                 queryParameters, commandType: CommandType.StoredProcedure);
            result = Convert.ToInt32(queryParameters.Get<int>("@nresult"));


            return result;
        }
        
        public async Task<List<ConfigLevelNineBoxDto>> GetConfigLevelNineBox()
        {

            var result = await humanManagementReadDbConnection.QueryAsync<ConfigLevelNineBoxDto>(
                 "campaign.sps_get_config_level_ninebox",
                 null, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        
        public async Task<List<ConfigLevelNineBoxDto>> GetConfigDetailLevelNineBoxByCampaign(ConfigDetailLevelNineBoxFilter filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_campaign", filter.nid_campaing);

            var result = await humanManagementReadDbConnection.QueryAsync<ConfigLevelNineBoxDto>(
                 "campaign.sps_get_config_detail_level_ninebox_by_campaign",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<CampaignProgressDto>> GetCampaignProgress(CampaignProgressFilterDto filter)
        {

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_campaign", filter.IdCampaign);
            queryParameters.Add("@nidcompany", filter.CompanyId);
            queryParameters.Add("@nidgerencia", filter.GerenciaId);
            queryParameters.Add("@nidarea", filter.AreaId);
            queryParameters.Add("@nidsubarea", filter.SubAreaId);
            queryParameters.Add("@number_action", filter.numberAction);
            queryParameters.Add("@statusetapa", filter.statusEtapa);

            var result = await humanManagementReadDbConnection.QueryAsync<CampaignProgressDto>(
                 "campaign.sps_rptprogresscampaign",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<MyTeamResumeDto>> GetMyTeamResume(MyTeamResumeFilterDto filter)
        {

            var queryParameters = new DynamicParameters(); 

            queryParameters.Add("@nidcampana", filter.nidCampana);
            queryParameters.Add("@nidgerencia", filter.gerenciaid);
            queryParameters.Add("@nidarea", filter.areaid);
            queryParameters.Add("@nidsubarea", filter.subareaid);
            queryParameters.Add("@nidcompany", filter.companyid);
            queryParameters.Add("@nidcargo", filter.nidcargo);

            var result = await humanManagementReadDbConnection.QueryAsync<MyTeamResumeDto>(
                 "campaign.sps_myteamresume",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<MyTeamResumeCompDto>> GetMyTeamResumeComp(MyTeamResumeFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcampana", filter.nidCampana);
            queryParameters.Add("@nidgerencia", filter.gerenciaid);
            queryParameters.Add("@nidarea", filter.areaid);
            queryParameters.Add("@nidsubarea", filter.subareaid);
            queryParameters.Add("@nidcompany", filter.companyid);
            queryParameters.Add("@nidcargo", filter.nidcargo);
            queryParameters.Add("@nidcargo", filter.nidcargo);
            queryParameters.Add("@nid_employee", filter.nid_employee);

            var result = await humanManagementReadDbConnection.QueryAsync<MyTeamResumeCompDto>(
                 "campaign.sps_myteamresume_comp",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<MyTeamResumeObjDto>> GetMyTeamResumeObj(MyTeamResumeFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcampana", filter.nidCampana);
            queryParameters.Add("@nidgerencia", filter.gerenciaid);
            queryParameters.Add("@nidarea", filter.areaid);
            queryParameters.Add("@nidsubarea", filter.subareaid);
            queryParameters.Add("@nidcompany", filter.companyid);
            queryParameters.Add("@nidcargo", filter.nidcargo);


            var result = await humanManagementReadDbConnection.QueryAsync<MyTeamResumeObjDto>(
                     "campaign.sps_myteamresume_obj",
                     queryParameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<CampaingByEvaluationDto>> GetCampaingByUser(CampaingByUserFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_employee", filter.nidEmployee);
            var listCampaing = await humanManagementReadDbConnection.QueryAsync<CampaingByEvaluationDto>(
                 "campaign.sps_get_campaing_by_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listCampaing.ToList();
        }
        public async Task<List<MyTeamResumeListDto>> GetMyTeamResumeList(MyTeamResumeFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcampana", filter.nidCampana);
            queryParameters.Add("@nidgerencia", filter.gerenciaid);
            queryParameters.Add("@nidarea", filter.areaid);
            queryParameters.Add("@nidsubarea", filter.subareaid);
            queryParameters.Add("@nidcompany", filter.companyid);
            queryParameters.Add("@nidcargo", filter.nidcargo);

            var result = await humanManagementReadDbConnection.QueryAsync<MyTeamResumeListDto>(
                 "campaign.sps_myteamresume_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<ResumenEvaluationDto>> GetNineBoxCopy(MyTeamResultadoFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", filter.nidcompany);
            queryParameters.Add("@nidgerencia", filter.nidgerencia);
            queryParameters.Add("@nidarea", filter.nidarea);
            queryParameters.Add("@nidsubarea", filter.nidsubarea);
            queryParameters.Add("@nidcargo", filter.nidcargo);
            queryParameters.Add("@nidcampana", filter.nidcampana);
            queryParameters.Add("@nid_employee", filter.nid_employee);
            //queryParameters.Add("@list_conceptos", filter.list_conceptos);


            var list = await humanManagementReadDbConnection.QueryAsync<ResumenEvaluationDto>(
                 "campaign.sps_my_team_resume_grafico_resultado",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

    }
}
