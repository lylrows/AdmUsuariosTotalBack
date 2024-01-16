using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class BudgetRepository : BaseRepository<Budget>, IBudgetRepository
    {

        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public BudgetRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }



        public async Task<List<BudgetListDto>> GetBudgetList(BudgetFilterDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@ncurrendperiod", filter.Period);
            queryParameters.Add("@nmonth", filter.Month);
            queryParameters.Add("@nidaregroup", filter.IdAreaGroup);
            queryParameters.Add("@sareascentercosts", filter.AreaCenterCosts);



            var list = await humanManagementReadDbConnection.QueryAsync<BudgetListDto>(
                 "salaryband.sps_budgetresume",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }
    }
}
