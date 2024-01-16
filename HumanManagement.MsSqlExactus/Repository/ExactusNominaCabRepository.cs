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
    public class ExactusNominaCabRepository : IExactusNominaCabRepository
    {
        private readonly IExactusReadDbConnection exactusReadDbConnection;
        private readonly ILogger<ExactusMedicalRequestRepository> _logger;
        public ExactusNominaCabRepository(IExactusReadDbConnection exactusReadDbConnection, ILogger<ExactusMedicalRequestRepository> _logger)
        {
            this.exactusReadDbConnection = exactusReadDbConnection;
            this._logger = _logger;
        }

        public async Task<List<ExactusNominaCab>> GetAll(ExactusNominaCabFilterDto filterDto)
        {
            try
            {
                string storename = $"[{filterDto.Scheme}].[EFITEC_NOMINACAB]";

                var queryParameters = new DynamicParameters();

                _logger.LogError($"Se ejecutará el procedimiento en exactus: {storename}");

                var list = await exactusReadDbConnection.QueryAsync<ExactusNominaCab>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);


                return list.ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
            return new  List<ExactusNominaCab>();
        }


        public async Task<List<ExactusLiquidacionCab>> GetLiquidacionCab(string sSchema)
        {
            try
            {
                string storename = $"[{sSchema}].[EFITEC_LEERLIQUIDACION]";

                var queryParameters = new DynamicParameters();


                var list = await exactusReadDbConnection.QueryAsync<ExactusLiquidacionCab>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);


                return list.ToList();

            }
            catch (Exception ex)
            {

                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
            return new List<ExactusLiquidacionCab>();
        }



        public async Task<List<ExactusLiquidacionDet>> GetLiquidacionDet(string sSchema,int nliquidation)
        {
            try
            {
                string storename = $"[{sSchema}].[EFITEC_LEERLIQUIDACION_CONC]";

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PNLIQUIDACION", nliquidation);

                var list = await exactusReadDbConnection.QueryAsync<ExactusLiquidacionDet>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);
                return list.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
            return new List<ExactusLiquidacionDet>();
        }
    }
}
