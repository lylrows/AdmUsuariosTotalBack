using Dapper;
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
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class EconomicConditionRepository : BaseRepository<EconomicCondition>, IEconomicConditionRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public EconomicConditionRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<EconomicCondition> FindById(int id)
        {
            var result = await (from pers in context.tb_economiccondition
                                where pers.IdEconomicCondition == id
                                && pers.Active
                                select pers).FirstOrDefaultAsync();

            return result;
        }


        public async Task<List<SalaryStructureList>> GetSalaryStructure(SalaryStructureFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nperiod",filter.Period);
            queryParameters.Add("@ncompanyid", filter.IdCompany);
            queryParameters.Add("@nid_area", filter.IdArea);
            queryParameters.Add("@ncargoid", filter.IdCargo);
            queryParameters.Add("@schargename", filter.ChargeName);
            queryParameters.Add("@nmonth", filter.Month);
            queryParameters.Add("@nid_gerencia", filter.IdGerencia);
            queryParameters.Add("@nid_subarea", filter.IdSubArea);
            queryParameters.Add("@sareacc", filter.AreaCC);

            var list = await humanManagementReadDbConnection.QueryAsync<SalaryStructureList>(
                 "salaryband.sps_salarystructure",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

    }
}
