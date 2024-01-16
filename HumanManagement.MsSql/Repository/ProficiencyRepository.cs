using Dapper;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Campaign.Models;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Proficiency.Contracts;
using HumanManagement.Domain.Proficiency.Dto;
using HumanManagement.Domain.Proficiency.Models;
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
    public class ProficiencyRepository : BaseRepository<Proficiency>, IProficiencyRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public ProficiencyRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task<List<ProficiencyDto>> getListProficiencies()
        {

            var list = await humanManagementReadDbConnection.QueryAsync<ProficiencyDto>(
                 "campaign.sps_get_proficiencies",
                 null, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }
    }
}
