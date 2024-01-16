using Dapper;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class SalaryBandRepository : BaseRepository<SalaryBand>, ISalaryBandRepository
    {

        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public SalaryBandRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task<ResultPaginationListDto<SalaryBandListDto>> GetBandBoxPagination(SalaryBandQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<SalaryBandListDto>(
                 "salaryband.sps_bandbox_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<SalaryBandListDto> result = new ResultPaginationListDto<SalaryBandListDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }

        public async Task<List<DropDownListDto<int>>> ListGroupCombo()
        {
            var result = await (from gr in context.tb_groupsalaryband
                                select new DropDownListDto<int> { 
                                Code = gr.IdGroup,
                                Description = gr.NameGroup
                                }).ToListAsync();

            return result;
        }

        public async Task<List<ListGroupDto>> GetListGroupSalary()
        {
            var result = await humanManagementReadDbConnection.QueryAsync<ListGroupDto>(
                 "salaryband.sp_get_list_group",
                 null, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<DropDownListString>> GetListAreaGroupCenterCost(int nid_areagroup)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_areagroup", nid_areagroup);

            var result = await humanManagementReadDbConnection.QueryAsync<DropDownListString>(
                        "salaryband.sps_getareacentercost",
                        queryParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<DropDownListString>> GetListAreaCCByGerencia(int nid_gerencia)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidupperarea", nid_gerencia);

            var result = await humanManagementReadDbConnection.QueryAsync<DropDownListString>(
                        "salaryband.sps_getareaCCbygerencia",
                        queryParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public async Task<SalaryBand> FindSalaryBandByGroupActive(int nIdGroup)
        {
            var result = await (from pers in context.tb_salaryband
                                where pers.IdGroup == nIdGroup
                                && pers.Active
                                select pers).FirstOrDefaultAsync();

            return result;
        }
        public async Task<SalaryBand> FindSalaryBandById(int id)
        {
            var result = await (from pers in context.tb_salaryband
                                where pers.IdBandBox== id
                                && pers.Active
                                select pers).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<EcoConditionListDto>> GetEcoConditionList(EcoConditionFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@period", filter.Period);
            queryParameters.Add("@nid_company", filter.IdCompany);
            queryParameters.Add("@ncargoid", filter.IdCargo);
            queryParameters.Add("@nmonth", filter.Month);
            queryParameters.Add("@nid_gerencia", filter.IdGerencia);
            queryParameters.Add("@nid_area", filter.IdArea);
            queryParameters.Add("@nid_subarea", filter.IdSubArea);
            queryParameters.Add("@schargename", filter.ChargeName);
            queryParameters.Add("@sareacc", filter.AreaCC);

            var list = await humanManagementReadDbConnection.QueryAsync<EcoConditionListDto>(
                 "salaryband.sps_economic_condition",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }


        public async Task<List<SalaryPayrollDet>> GetSalaryPayrollDets(string snomina,int nnumeronomina,int nidcompany)
        {
            var result = await (from det in context.tb_salarypayrolldet
                                where det.Payroll == snomina && det.PayRollNumber == nnumeronomina &&  det.IdCompany==  nidcompany 
                                select det).ToListAsync();

            return result;
        }


        public async Task<int> RegisterNominaCab(SalaryPayrollCab salaryPayrollcab)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;


            queryParameters.Add("@nidcompany"       , salaryPayrollcab.IdCompany);
            queryParameters.Add("@snominacode"      , salaryPayrollcab.NominaCode);
            queryParameters.Add("@snominanumber"    , salaryPayrollcab.NominaNumber);
            queryParameters.Add("@nyear"            , salaryPayrollcab.Year);
            queryParameters.Add("@nmonth"           , salaryPayrollcab.Month);
            queryParameters.Add("@PERIODO"          , salaryPayrollcab.PERIODO);
            queryParameters.Add("@FECHA_APROBACION" , salaryPayrollcab.FECHA_APROBACION);
            queryParameters.Add("@FECHA_PAGO"       , salaryPayrollcab.FECHA_PAGO);
            queryParameters.Add("@APROBADA_POR", salaryPayrollcab.APROBADA_POR);


            


            var res = await humanManagementReadDbConnection.QueryAsync<int>(
                  "salaryband.spi_register_nominacab",
                  queryParameters, commandType: CommandType.StoredProcedure);
            
            result =  int.Parse(res[0].ToString());

            return result;
        }



        public async Task<int> RegisterNominaDetail(SalaryPayrollDet salaryPayrollDet)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;

            queryParameters.Add("@IdCompany", salaryPayrollDet.IdCompany);
            queryParameters.Add("@Consecutive", salaryPayrollDet.Consecutive);
            queryParameters.Add("@CodEmployee", salaryPayrollDet.CodEmployee);
            queryParameters.Add("@Concept", salaryPayrollDet.Concept);
            queryParameters.Add("@Payroll", salaryPayrollDet.Payroll);
            queryParameters.Add("@PayRollNumber", salaryPayrollDet.PayRollNumber);
            queryParameters.Add("@CostCenter", salaryPayrollDet.CostCenter);
            queryParameters.Add("@Amount", salaryPayrollDet.Amount);
            queryParameters.Add("@Total", salaryPayrollDet.Total);
            queryParameters.Add("@RegisterType", salaryPayrollDet.RegisterType);


            


            var res = await humanManagementReadDbConnection.QueryAsync<int>(
                  "salaryband.spi_register_nominadetail",
                  queryParameters, commandType: CommandType.StoredProcedure);
            
            result = 1;

            return result;
        }


        public async Task<List<LiquidacionCabDto>> GetLiquidacionCabList(int nid_company)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_company", nid_company);
            

            var list = await humanManagementReadDbConnection.QueryAsync<LiquidacionCabDto>(
                 "salaryband.sps_liquidacion_cab",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }


        public async Task<int> RegisterLiquidacionCab(LiquidacionCabDto dto)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;

            queryParameters.Add("@nidcompany", dto.nidcompany);
            queryParameters.Add("@nliquidation", dto.nliquidation);
            queryParameters.Add("@scodemployee", dto.scodemployee);
            queryParameters.Add("@scurrency", dto.scurrency);
            queryParameters.Add("@sstateliquidation", dto.sstateliquidation);
            queryParameters.Add("@ddate_in", dto.ddate_in);
            queryParameters.Add("@ddate_out", dto.ddate_out);
            queryParameters.Add("@sclose_contracts", dto.sclose_contracts);
            queryParameters.Add("@nnumberaction", dto.nnumberaction);
            queryParameters.Add("@spayway", dto.spayway);
            queryParameters.Add("@saccountbank", dto.saccountbank);
            queryParameters.Add("@snumber_document_pay", dto.snumber_document_pay);
            queryParameters.Add("@saccountseat", dto.saccountseat);
            queryParameters.Add("@ddate_out_pay", dto.ddate_out_pay);
            queryParameters.Add("@suser_liquidation", dto.suser_liquidation);
            queryParameters.Add("@ddate_liquidation", dto.ddate_liquidation);
            queryParameters.Add("@nsubtypedoc_pay", dto.nsubtypedoc_pay);
            queryParameters.Add("@sbudget", dto.sbudget);
            queryParameters.Add("@sunit_operative", dto.sunit_operative);
            queryParameters.Add("@nnumber_apart", dto.nnumber_apart);
            queryParameters.Add("@nnumber_exercised", dto.nnumber_exercised);
            queryParameters.Add("@scalc_pay_nomina", dto.scalc_pay_nomina);
            queryParameters.Add("@snomina_calc", dto.snomina_calc);
            queryParameters.Add("@nnumber_nomina_calc", dto.nnumber_nomina_calc);
            queryParameters.Add("@scontract_term_type", dto.scontract_term_type);
            queryParameters.Add("@ssituation_unac", dto.ssituation_unac);
            queryParameters.Add("@order_spin", dto.order_spin);

            var res = await humanManagementReadDbConnection.QueryAsync<int>(
                  "salaryband.spi_liquidacion_cab",
                  queryParameters, commandType: CommandType.StoredProcedure);
            
            result = 1;

            return result;
        }

        public async Task<int> RegisterLiquidacionDet(LiquidacionDetDto dto)
        {
            var queryParameters = new DynamicParameters();
            int result = 0;

                queryParameters.Add("@nidcompany"       , dto.nidcompany	        );
                queryParameters.Add("@nliquidation"     , dto.nliquidation	        );
                queryParameters.Add("@nline"            , dto.nline			        );
                queryParameters.Add("@sconcept"         , dto.sconcept		        );
                queryParameters.Add("@sdescription"     , dto.sdescription	        );
                queryParameters.Add("@stypeconcept"     , dto.stypeconcept	        );
                queryParameters.Add("@nsequence"        , dto.nsequence		        );
                queryParameters.Add("@nquantity"        , dto.nquantity		        );
                queryParameters.Add("@namount"          , dto.namount		        );
                queryParameters.Add("@ntotal_calc"      , dto.ntotal_calc	        );
                queryParameters.Add("@scentercost"      , dto.scentercost	        );
                queryParameters.Add("@sledgeraccount", dto.sledgeraccount);



            var res = await humanManagementReadDbConnection.QueryAsync<int>(
                  "salaryband.spi_liquidacion_det",
                  queryParameters, commandType: CommandType.StoredProcedure);
            
            result = 1;

            return result;
        }
        
    }
}
