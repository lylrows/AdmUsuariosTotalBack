using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSqlExactus.Repository
{
    public class ExactusNominaRepository : IExactusNominaRepository
    {
        private readonly IExactusReadDbConnection exactusReadDbConnection;
        private readonly ILogger<ExactusNominaRepository> _logger;
        public ExactusNominaRepository(IExactusReadDbConnection exactusReadDbConnection, ILogger<ExactusNominaRepository> _logger)
        {
            this.exactusReadDbConnection = exactusReadDbConnection;
            this._logger = _logger;
        }

        public async Task<List<ExactusNomina>> GetAll(ExactusNominaFilterDto filterDto)
        {
            
            try
            {
                string storename = $"[{filterDto.Scheme}].[EFITEC_NOMINADET]";

                var queryParameters = new DynamicParameters();

                queryParameters.Add("@PSNOMINA", filterDto.NominaCode);
                queryParameters.Add("@PNNUMERO_NOMINA", filterDto.NominaNumber);

                var list = await exactusReadDbConnection.QueryAsync<ExactusNomina>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);


                return list.ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
            return new List<ExactusNomina>();
        }
    }
}
