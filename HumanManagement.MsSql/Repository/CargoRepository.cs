using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Cargo.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Cargo.QueryFilter;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Common;
using Dapper;
using System.Data;
using HumanManagement.Domain.EvaluationPostulant.Dto;

namespace HumanManagement.MsSql.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;

        public CargoRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task<int> AddCharge(CargoDto requestQueryFilter)
        {
                var queryParameters = new DynamicParameters();
                
                queryParameters.Add("@nid_area", requestQueryFilter.IdArea);
                queryParameters.Add("@nid_company", requestQueryFilter.IdEmpresa);
                queryParameters.Add("@snamechange", requestQueryFilter.NameCargo);
                queryParameters.Add("@nid_charge", DbType.Int32, direction: ParameterDirection.Output);

            var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                     "sps_save_charge",
                     queryParameters, commandType: CommandType.StoredProcedure);

            int _id_charge = Convert.ToInt32(queryParameters.Get<int>("@nid_charge"));

            return Convert.ToInt32(queryParameters.Get<int>("@nid_charge"));

        }
        public async Task<int> AddCargoConfig(List<CargoCompetenciaDto> competencias)
        {
            try
            {

                foreach (var _cargoCompetencia in competencias)
                {
                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@nid_request", _cargoCompetencia.IdRequest);
                    queryParameters.Add("@nidcharge", _cargoCompetencia.IdCharge);
                    queryParameters.Add("@nid_profiency", _cargoCompetencia.Id);
                    queryParameters.Add("@nlevel", _cargoCompetencia.IdLevel);
                    queryParameters.Add("@nuser", _cargoCompetencia.UserRegister);
                    queryParameters.Add("@nresult", DbType.Int32, direction: ParameterDirection.Output);

                    var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                         
                         "sps_save_mof_detail_proficiency_temp",
                         queryParameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                var resultado = ex;
            }
            return 1;
        }

        public async Task<ResultPaginationListDto<CargoDto>> GetAll(CargoQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_company", contactQueryFilter.IdCompany);
            queryParameters.Add("@nid_gerencia", contactQueryFilter.IdGerencia);
            queryParameters.Add("@nid_area", contactQueryFilter.IdArea);
            queryParameters.Add("@nid_subarea", contactQueryFilter.IdSubArea);
            queryParameters.Add("@snamecargo", contactQueryFilter.NombreCargo.Trim());
            queryParameters.Add("@sestado", contactQueryFilter.Estado.Trim());
            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<CargoDto>(
                 "sps_charge_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<CargoDto> result = new ResultPaginationListDto<CargoDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }
        public async Task<List<CargoDto>> GetCargoByEmpresa(FilterCargoDto dto)
        {
         
                var cargos = await (from p in context.tb_charge
                                    where
                                        (dto.IdEmpresa == 0 || p.IdEmpresa == dto.IdEmpresa)
                                    && (dto.IdArea == 0 || p.IdArea == dto.IdArea)
                                    
                                    select new CargoDto
                                    {
                                        Id = p.Id,
                                        NameCargo = p.NameCargo
                                    }).ToListAsync();
                return cargos;
           
        }
        public async Task<int> GetIdByCode(string codeCharge)
        {
            var charge = await (from p in context.tb_charge
                                where p.CodecCharge.Equals(codeCharge)
                                select new CargoDto
                                {
                                    Id = p.Id
                                }).SingleOrDefaultAsync();

            return charge == null ? 0 : charge.Id;
        }

        public async Task<int> GetJefeByCharge(int IdCharge)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidcharge", IdCharge);
            queryParameters.Add("@nidjefe", DbType.Int32 ,direction: ParameterDirection.Output);

            var result = await humanManagementReadDbConnection.QueryAsync<int>(
                 "sp_get_jefe_for_charge",
                 queryParameters, commandType: CommandType.StoredProcedure);
            int idjefe = Convert.ToInt32(queryParameters.Get<int>("@nidjefe"));

            return idjefe;
        }

        public async Task<List<CargoDto>> GetListCargo()
        {
            var queryParameters = new DynamicParameters();

            var listContacts = await humanManagementReadDbConnection.QueryAsync<CargoDto>(
                 "sps_charge_get_all",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return listContacts.ToList();
        }

        public async Task<List<CargoCompetenciaDto>> GetListCompetenciasByCargo(int idRequest, int idCargo, int primeraCarga)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", idRequest);
            queryParameters.Add("@nidcharge", idCargo);
            queryParameters.Add("@nprimera_carga", primeraCarga);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<CargoCompetenciaDto>(
                 "sps_list_mof_detail_proficiency",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return listContacts.ToList();
        }

        public async Task<List<CargoByCompanyAreaDto>> GetChargesByCompanyArea(ChargesByCompanyAreaFilter chargesByCompanyAreaFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", chargesByCompanyAreaFilter.nidcompany);
            queryParameters.Add("@nidgerencia", chargesByCompanyAreaFilter.nidgerencia);
            queryParameters.Add("@nidarea", chargesByCompanyAreaFilter.nidarea);
            queryParameters.Add("@nidsubarea", chargesByCompanyAreaFilter.nidsubarea);

            var result = await humanManagementReadDbConnection.QueryAsync<CargoByCompanyAreaDto>(
                 "sps_get_charges_company_area",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<CargoByCompanyAreaDto>> GetChargesByCompanyAreaMulti(ChargesByCompanyAreaMultiFilter chargesByCompanyAreaFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", chargesByCompanyAreaFilter.nidcompany);
            queryParameters.Add("@nidgerencia", chargesByCompanyAreaFilter.nidgerencia);
            queryParameters.Add("@nidarea", chargesByCompanyAreaFilter.nidarea);
            queryParameters.Add("@nidsubarea", chargesByCompanyAreaFilter.nidsubarea);

            var result = await humanManagementReadDbConnection.QueryAsync<CargoByCompanyAreaDto>(
                 "sps_get_charges_company_areamulti",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }


        public async Task<List<EvaluatorDto>> GetMailsByEvaluation(int idEvaluationPostulant)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_evaluation_postulant", idEvaluationPostulant);

            var result = await humanManagementReadDbConnection.QueryAsync<EvaluatorDto>(
                 "[recruitment].[sps_mails_by_evaluation]",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<EvaluatorDto>> GetMailsByEvaluationInternal(int idEvaluationPostulant)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_evaluation_postulant", idEvaluationPostulant);

            var result = await humanManagementReadDbConnection.QueryAsync<EvaluatorDto>(
                 "[sps_mails_by_evaluation_internal]",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }


        public async Task<List<CargoByCompanyAreaDto>> GetChargesByCompanyAreav2(ChargesByCompanyAreaFilter chargesByCompanyAreaFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", chargesByCompanyAreaFilter.nidcompany);
            queryParameters.Add("@nidgerencia", chargesByCompanyAreaFilter.nidgerencia);
            queryParameters.Add("@nidarea", chargesByCompanyAreaFilter.nidarea);
            queryParameters.Add("@nidsubarea", chargesByCompanyAreaFilter.nidsubarea);

            var result = await humanManagementReadDbConnection.QueryAsync<CargoByCompanyAreaDto>(
                 "sps_get_charges_company_areav2",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
    }
}
