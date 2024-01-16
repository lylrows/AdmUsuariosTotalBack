using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using Microsoft.Extensions.Logging;
using System;

using System.Data;

using System.Threading.Tasks;

namespace HumanManagement.MsSqlExactus.Repository
{

    public class ExactusMedicalRequestRepository : IExactusMedicalRequestRepository
    {
        private readonly IExactusReadDbConnection exactusReadDbConnection;
        private readonly ILogger<ExactusMedicalRequestRepository> _logger;
        public ExactusMedicalRequestRepository(IExactusReadDbConnection exactusReadDbConnection, ILogger<ExactusMedicalRequestRepository> _logger)
        {
            this.exactusReadDbConnection = exactusReadDbConnection;
            this._logger = _logger;
        }

        public async Task<ExactusDiasVacacionesDto> GetVacationsDays(string scode_employee, string scode_esquema)
        {
            ExactusDiasVacacionesDto vacacionesDto=new ExactusDiasVacacionesDto();
            try
            {
                string sqlstore = string.Format("{0}.GRUPOFE_SALDO_VACACIONES", scode_esquema);

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@empleado", scode_employee);
                queryParameters.Add("@fecha_actual", DateTime.Now.ToString("yyyy-MM-dd"));
                //queryParameters.Add("@fecha_actual", DateTime.Now.ToShortDateString());


                _logger.LogInformation("@empleado                :   " + scode_employee);
                _logger.LogInformation("@fecha_actual            :   " + DateTime.Now);


                var _value = await exactusReadDbConnection.QueryAsync<ExactusDiasVacacionesDto>(
                     sqlstore,
                     queryParameters, commandType: CommandType.StoredProcedure);

                _logger.LogInformation("Se ejecutó el procedimiento correctamente");
                vacacionesDto.saldo_vacaciones = _value[0].saldo_vacaciones;
                vacacionesDto.tipo = _value[0].tipo;
                vacacionesDto.vencido = _value[0].vencido;
                vacacionesDto.trunco = _value[0].trunco;

                ////Para prueba
                //vacacionesDto.saldo_vacaciones = 23;
                //vacacionesDto.tipo = 2;
                //vacacionesDto.vencido = 12;
                //vacacionesDto.trunco = 32;

                return vacacionesDto;

            }
            catch (Exception ex)
            {
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error - GetVacationsDays: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error - GetVacationsDays: " + ex.StackTrace);
                //return 0.00m;
                vacacionesDto.saldo_vacaciones = 0.00m;
                vacacionesDto.vencido = 0.00m;
                vacacionesDto.tipo = 0;
                vacacionesDto.trunco = 0.00m;

                return vacacionesDto;
            }
        }

        public async Task<ExactusMedicalRequestInsSpDto> InsertMedicalRequestSP(ExactusMedicalRequestInsSpDto dto)
        {
            try
            {
                string sqlstore = string.Format("{0}.EXACTUS_RH_ACCION_PERSONAL", dto.Schema);

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PSCONJUNTO", dto.PSCONJUNTO);
                queryParameters.Add("@PSUSUARIO", dto.PSUSUARIO);
                queryParameters.Add("@PSEMPLEADO", dto.PSEMPLEADO);
                queryParameters.Add("@PSTIPOACCION", dto.PSTIPOACCION);
                queryParameters.Add("@PDTFECHA", dto.PDTFECHA);
                queryParameters.Add("@PDTFECHARIGE", dto.PDTFECHARIGE);
                queryParameters.Add("@PDTFECHAVENCE", dto.PDTFECHAVENCE);
                queryParameters.Add("@PNDIASACCION", dto.PNDIASACCION);
                queryParameters.Add("@PSNOMINA", dto.PSNOMINA);
                queryParameters.Add("@PSPUESTO", dto.PSPUESTO);
                queryParameters.Add("@PSPLAZA", dto.PSPLAZA);
                queryParameters.Add("@PSDEPARTAMENTO", dto.PSDEPARTAMENTO);
                queryParameters.Add("@PSCENTROCOSTO", dto.PSCENTROCOSTO);
                queryParameters.Add("@PNSALARIOREFERENCIA", dto.PNSALARIOREFERENCIA);
                queryParameters.Add("@PSTIPOAUSENCIA", dto.PSTIPOAUSENCIA);
                queryParameters.Add("@PSESTADOEMPLEADO", dto.PSESTADOEMPLEADO);
                queryParameters.Add("@PSRUBRO1", dto.PSRUBRO1);
                queryParameters.Add("@PSRUBRO2", dto.PSRUBRO2);
                queryParameters.Add("@PSRUBRO3", dto.PSRUBRO3);
                queryParameters.Add("@PSRUBRO4", dto.PSRUBRO4);
                queryParameters.Add("@PSRUBRO5", dto.PSRUBRO5);
                queryParameters.Add("@PSRUBRO6", dto.PSRUBRO6);
                queryParameters.Add("@PSRUBRO7", dto.PSRUBRO7);
                queryParameters.Add("@PSRUBRO8", dto.PSRUBRO8);
                queryParameters.Add("@PSRUBRO9", dto.PSRUBRO9);
                queryParameters.Add("@PSRUBRO10", dto.PSRUBRO10);
                queryParameters.Add("@PSNOTAS", dto.PSNOTAS);
                queryParameters.Add("@PNNUMEROACCION", DbType.Int32, direction: ParameterDirection.Output);
                queryParameters.Add("@PSMENSAJEERROR","PRUEBA",DbType.String, direction: ParameterDirection.Output,250);
                

                _logger.LogInformation("dtoexactus.Schema                :   " + dto.Schema);
                _logger.LogInformation("dtoexactus.PSCONJUNTO            :   " + dto.PSCONJUNTO);
                _logger.LogInformation("dtoexactus.PSUSUARIO             :   " + dto.PSUSUARIO);
                _logger.LogInformation("dtoexactus.PSEMPLEADO            :   " + dto.PSEMPLEADO);
                _logger.LogInformation("dtoexactus.PSTIPOACCION          :   " + dto.PSTIPOACCION);
                _logger.LogInformation("dtoexactus.PDTFECHA              :   " + dto.PDTFECHA);
                _logger.LogInformation("dtoexactus.PDTFECHARIGE          :   " + dto.PDTFECHARIGE);
                _logger.LogInformation("dtoexactus.PDTFECHAVENCE         :   " + dto.PDTFECHAVENCE);
                _logger.LogInformation("dtoexactus.PNDIASACCION          :   " + dto.PNDIASACCION);
                _logger.LogInformation("dtoexactus.PSNOMINA              :   " + dto.PSNOMINA);
                _logger.LogInformation("dtoexactus.PSPUESTO              :   " + dto.PSPUESTO);
                _logger.LogInformation("dtoexactus.PSPLAZA               :   " + dto.PSPLAZA);
                _logger.LogInformation("dtoexactus.PSDEPARTAMENTO        :   " + dto.PSDEPARTAMENTO);
                _logger.LogInformation("dtoexactus.PSCENTROCOSTO         :   " + dto.PSCENTROCOSTO);
                _logger.LogInformation("dtoexactus.PNSALARIOREFERENCIA   :   " + dto.PNSALARIOREFERENCIA);
                _logger.LogInformation("dtoexactus.PSTIPOAUSENCIA        :   " + dto.PSTIPOAUSENCIA);
                _logger.LogInformation("dtoexactus.PSESTADOEMPLEADO      :   " + dto.PSESTADOEMPLEADO);
                _logger.LogInformation("dtoexactus.PSRUBRO1              :   " + dto.PSRUBRO1);
                _logger.LogInformation("dtoexactus.PSRUBRO2              :   " + dto.PSRUBRO2);
                _logger.LogInformation("dtoexactus.PSRUBRO3              :   " + dto.PSRUBRO3);
                _logger.LogInformation("dtoexactus.PSRUBRO4              :   " + dto.PSRUBRO4);
                _logger.LogInformation("dtoexactus.PSRUBRO5              :   " + dto.PSRUBRO5);
                _logger.LogInformation("dtoexactus.PSRUBRO6              :   " + dto.PSRUBRO6);
                _logger.LogInformation("dtoexactus.PSRUBRO7              :   " + dto.PSRUBRO7);
                _logger.LogInformation("dtoexactus.PSRUBRO8              :   " + dto.PSRUBRO8);
                _logger.LogInformation("dtoexactus.PSRUBRO9              :   " + dto.PSRUBRO9);
                _logger.LogInformation("dtoexactus.PSRUBRO10             :   " + dto.PSRUBRO10);
                _logger.LogInformation("dtoexactus.PSNOTAS               :   " + dto.PSNOTAS);
                                                                             
                _logger.LogInformation("sqlstore=====>                   :   " + sqlstore);
                

                var listUSer = await exactusReadDbConnection.QueryAsync<object>(
                     sqlstore,
                     queryParameters, commandType: CommandType.StoredProcedure);

                _logger.LogInformation("Se ejecutó el procedimiento correctamente");

                dto.PSMENSAJEERROR = queryParameters.Get<string>("@PSMENSAJEERROR");
                dto.PNNUMEROACCION = (queryParameters.Get<int?>("@PNNUMEROACCION"))??0;
            }
            catch (Exception ex)
            {
                dto.PSMENSAJEERROR = "Error al ejecutar el procedimiento de exactus";
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
           


            return dto;
        }
    }
}
