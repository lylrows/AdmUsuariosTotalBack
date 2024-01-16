using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mof.Contracts;
using HumanManagement.Domain.Mof.Dto;
using HumanManagement.MsSql.Context;

using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class MofRepository : IMofRepository
    {

        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;
        public MofRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, DbContextMsSql context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
        }



        public async Task<List<MofDetailProfListDto>> GetMofDetailProfList(MofFilter filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_company", filter.CompanyId);
            queryParameters.Add("@nid_gerencia", filter.GerenciaId);
            queryParameters.Add("@nid_area", filter.AreaId);
            queryParameters.Add("@nid_subarea", filter.SubAreaId);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<MofDetailProfListDto>(
                 "sps_profbychargemof_max",
                 queryParameters, commandType: CommandType.StoredProcedure);

            

            return listUSer.ToList();
        }

        public async Task<List<MofDetailProfListDto>> GetMofDetailProfListsByCharge(int IdCharge)
        {
            var queryParameters = new DynamicParameters();
              queryParameters.Add("@idcharge", IdCharge);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<MofDetailProfListDto>(
                 "sps_profbycharge",
                 queryParameters, commandType: CommandType.StoredProcedure);



            return listUSer.ToList();
        }
    }
}
