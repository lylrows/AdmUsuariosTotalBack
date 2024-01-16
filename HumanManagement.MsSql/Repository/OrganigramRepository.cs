using HumanManagement.Domain.Organigram.Contracts;
using HumanManagement.Domain.Organigram.Dto;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.Domain.Contracts;
using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;

namespace HumanManagement.MsSql.Repository
{
    public class OrganigramRepository : IOrganigramRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly ILogger<OrganigramRepository> _logger;

        public OrganigramRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, ILogger<OrganigramRepository> _logger)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this._logger = _logger;
        
        }
        public async Task<List<AreaCargoDto>> GetOrganigram(int idEmpresa)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_company", idEmpresa);
            var listOrg = await humanManagementReadDbConnection.QueryAsync<AreaCargoDto>(
                 "sp_get_organigram",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listOrg.ToList();

        }

        public async Task<List<AreaCargoDto>> GetOrganigramDetail(int idEmpresa, int idArea, int idCargo)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_company", idEmpresa);
            queryParameters.Add("@nid_area", idArea);
            queryParameters.Add("@nid_cargo", idCargo);
            var listOrg = await humanManagementReadDbConnection.QueryAsync<AreaCargoDto>(
                 "sp_get_organigram_detail",
                 queryParameters, commandType: CommandType.StoredProcedure);
            _logger.LogInformation("Se ejecutó  el procedimiento: sp_get_organigram_detail  correctamente. "+ listOrg.Count);
            return listOrg.ToList();
        }

        public async Task<List<AreaCargoDto>> GetOrganigramByCargo(int idEmpresa, int idArea, int idCargo)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_company", idEmpresa);
            queryParameters.Add("@nid_area", idArea);
            queryParameters.Add("@nid_cargo", idCargo);
            var listOrg = await humanManagementReadDbConnection.QueryAsync<AreaCargoDto>(
                 "sp_get_organigram_by_cargo",
                 queryParameters, commandType: CommandType.StoredProcedure);
            _logger.LogInformation("Se ejecutó  el procedimiento: sp_get_organigram_by_cargo  correctamente. " + listOrg.Count);

            return listOrg.ToList();
        }

        public async Task<List<OrganigramV2Dto>> GetOrganigramV2(int nidcompany)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidcompany", nidcompany);
            var listOrg = await humanManagementReadDbConnection.QueryAsync<OrganigramV2Dto>(
                 "sp_get_organigramv2",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listOrg.ToList();
        }
    }
}
