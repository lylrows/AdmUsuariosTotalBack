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
    public class ExactusDepartamentoRepository :  IExactusDepartamentoRepository
    {
        private readonly IExactusReadDbConnection   exactusReadDbConnection;
        private readonly ILogger<ExactusDepartamentoRepository> _logger;
        public ExactusDepartamentoRepository(IExactusReadDbConnection exactusReadDbConnection, ILogger<ExactusDepartamentoRepository> _logger)
        {
            this.exactusReadDbConnection = exactusReadDbConnection;
            this._logger = _logger;
        }

        public async Task<List<ExactusDepartamento>> GetAll(ExactusDepartmentFilterDto filterDto)
        {
            try
            {
                string storename = $"[{filterDto.Scheme}].[EFITEC_LEERDEPARTAMENTO]";

                var queryParameters = new DynamicParameters();

                var list = await exactusReadDbConnection.QueryAsync<ExactusDepartamento>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);

                return list.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
            return new List<ExactusDepartamento>();
        }
    }
}
