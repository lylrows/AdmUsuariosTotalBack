using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Areas.QueryFilter;
using System.Data;
using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Common;


namespace HumanManagement.MsSql.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public AreaRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<ResultPaginationListDto<AreasDto>> GetAll(AreasQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_company", contactQueryFilter.IdCompany);
            queryParameters.Add("@snamearea", contactQueryFilter.NombreArea.Trim());
            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<AreasDto>(
                 "sps_areas_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<AreasDto> result = new ResultPaginationListDto<AreasDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }

        public async Task<List<AreasDto>> GetAreasAll()
        {
            var queryParameters = new DynamicParameters();
            

            var listArea = await humanManagementReadDbConnection.QueryAsync<AreasDto>(
                 "sps_areas_get_all",
                 queryParameters, commandType: CommandType.StoredProcedure);



            return listArea.ToList();
        }

        public async Task<List<AreasDto>> GetByEmpresa(int idEmpresa)
        {
            var result = await (from p in context.tb_area
                                join e in context.tb_company on p.IdEmpresa equals e.Id
                                where (p.IdEmpresa == idEmpresa || idEmpresa == 0) && p.Active == true && p.IdUpperArea == 0
                                orderby p.NameArea
                                select new AreasDto
                                {
                                    Id = p.Id,
                                    IdEmpresa = e.Id,
                                    Empresa = e.Descripcion,
                                    NameArea = p.NameArea,
                                    Active = p.Active,
                                    State = p.State
                                }).ToListAsync();
            return result.OrderBy(a=>a.NameArea).ToList(); 
        }

        public async Task<int> GetByIdUser(int idUser)
        {
            var area = await (from a in context.tb_area
                        join c in context.tb_charge on a.Id equals c.IdArea
                        join e in context.Employee on
                        c.Id equals e.IdPosition
                        join p in context.Person on e.IdPerson equals p.Id
                        join u in context.User on p.Id equals u.IdPerson
                        where u.Id == idUser
                        select new
                        {
                            a.Id
                        }).FirstOrDefaultAsync();
            return area == null ? 0 : area.Id;
        }

        public async Task<List<AreasDto>> GetManagementByCompany(int idEmpresa)
        {
            var result = await (from p in context.tb_area
                                join e in context.tb_company on p.IdEmpresa equals e.Id
                                where (p.IdEmpresa == idEmpresa || idEmpresa == 0) && p.Active == true && p.IdUpperArea==0
                                orderby p.NameArea
                                select new AreasDto
                                {
                                    Id = p.Id,
                                    IdEmpresa = e.Id,
                                    Empresa = e.Descripcion,
                                    NameArea = p.NameArea,
                                    Active = p.Active,
                                    State = p.State
                                }).ToListAsync();
            return result;
        }

        public async Task<List<AreasDto>> GetAreaByManagement(int idManagement)
        {
            var result = await (from p in context.tb_area
                                join e in context.tb_company on p.IdEmpresa equals e.Id
                                where (p.IdUpperArea == idManagement || idManagement == 0) && p.Active == true
                                orderby p.NameArea
                                select new AreasDto
                                {
                                    Id = p.Id,
                                    IdEmpresa = e.Id,
                                    Empresa = e.Descripcion,
                                    NameArea = p.NameArea,
                                    Active = p.Active,
                                    State = p.State
                                }).ToListAsync();
            return result;
        }

        public async Task<List<AreasDto>> GetSubAreaByIdArea(int idArea)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_area", idArea);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasDto>(
                 "sps_get_subareas_by_idarea",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<AreasByUserDto> GetAreaByIdUser(int idUser)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_user", idUser);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasByUserDto>(
                 "sps_get_areas_by_user_id",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }

        public async Task<List<AreasComboDto>> GetGerenciasByUser(AreasComboQueryFilter filter)
        {
            
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@pnid_user", filter.IdUser);
            queryParameters.Add("@pnid_company", filter.IdCompany);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_gerencias_by_user_id",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
        
        public async Task<List<AreasComboDto>> GetSubAreasByArea(SubAreasComboQueryFilter filter)
        {

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@pnid_area", filter.IdArea);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_subareas_by_area_id",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
        public async Task<List<AreasComboDto>> GetSubAreasByAreaMultiple(string AreasIds)
        {

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@pnid_area", AreasIds);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_subareas_by_area_idMultiple",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }


        public async Task<List<CompanyComboDto>> GetCompanyByUser(CompanyComboQueryFilter filter)
        {

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@pnid_user", filter.IdUser);

            var result = await humanManagementReadDbConnection.QueryAsync<CompanyComboDto>(
                 "sps_get_company_by_user",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<AreasComboDto>> GetGerenciasByUserEvaluation(AreasComboQueryFilter filter)
        {

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@pnid_user", filter.IdUser);
            queryParameters.Add("@pnid_company", filter.IdCompany);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_gerencias_by_user_id_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<AreasComboDto>> GetAreasByGerenciaEvaluation(AreasEvaluationComboQueryFilter filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@pnid_user", filter.IdUser);
            queryParameters.Add("@pnid_area", filter.IdArea);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_areas_by_gerencia_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<AreasComboDto>> GetSubAreasByAreaEvaluation(SubAreasEvaluationComboQueryFilter filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@pnid_user", filter.IdUser);
            queryParameters.Add("@pnid_area", filter.IdArea);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_subareas_by_area_evaluation",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<AreasComboDto>> GetGerenciasByCompany(GerenciasComboQueryFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_company", filter.IdCompany);

            var result = await humanManagementReadDbConnection.QueryAsync<AreasComboDto>(
                 "sps_get_gerencias_by_company",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();

        }

        public async Task<List<JefesByAreaDto>> GetJefesByArea(JefesQueryFilter filter)
        {

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_gerencia", filter.IdGerencia);
            queryParameters.Add("@nid_area", filter.IdArea);
            queryParameters.Add("@nid_subarea", filter.IdSubArea);

            var result = await humanManagementReadDbConnection.QueryAsync<JefesByAreaDto>(
                 "sps_get_jefes_by_idarea",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
        
    }
}
