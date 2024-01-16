using Dapper;
using HumanManagement.Domain.Contracts.ServerUs;
using HumanManagement.Domain.WindowsService.ServerUs.Contracts;
using HumanManagement.Domain.WindowsService.ServerUs.Dto;

using Microsoft.Extensions.Logging;
using System;

using System.Data;

using System.Threading.Tasks;

namespace HumanManagement.MsSqlServerUs.Repository
{
  
    public class SUMovAsistenciaCabRepository : ISUMovAsistenciaCabRepository
    {
        private readonly IServerUsReadDbConnection ServerUsReadDbConnection;
        private readonly ILogger<SUMovAsistenciaCabRepository> _logger;
        public SUMovAsistenciaCabRepository(IServerUsReadDbConnection ServerUsReadDbConnection, ILogger<SUMovAsistenciaCabRepository> _logger)
        {
            this.ServerUsReadDbConnection = ServerUsReadDbConnection;
            this._logger = _logger;
        }

        public async Task<int> GetNewId(SUGetNewIdFilterDto filterDto)
        {
            string query = @"select  isnull(max (num_solicitud ),0)+1 from [RCA].[dMovAsistenciaCab]  
                                where identidad = <IDENTIDAD> 
                                and cod_tipo_solicitud ='<CODTIPOSOLICITUD>'
                                ";

            query = query.Replace("<IDENTIDAD>", filterDto.identidad.ToString());
            query = query.Replace("<CODTIPOSOLICITUD>", filterDto.cod_tipo_solicitud);

            _logger.LogInformation("QUERY===>" + query);

            var result = await ServerUsReadDbConnection.QueryAsync<int>(query,
                                            new
                                            {
                                                
                                            });

            return result[0];
        }

        public async Task<int> GetIdEmployee(int identidad , string codemployee)
        {
            string query = @"select  top 1  isnull(idtrabajador ,0) from [RGP].[pPersona]  
                                where identidad = <IDENTIDAD> 
                                and cod_libreta_electoral ='<CODEMPLEADO>' ";

            query = query.Replace("<IDENTIDAD>", identidad.ToString());
            query = query.Replace("<CODEMPLEADO>", codemployee);
            _logger.LogInformation("QUERY===>" + query);

            var result = await ServerUsReadDbConnection.QueryAsync<int>(query,
                                            new
                                            {
                                              
                                            });

            return result.Count > 0 ? result[0] :0 ;
        }

        public async Task<int> Insert(SUInsertMovCabDto insertDto)
        {

            string query = @"
                                INSERT INTO [RCA].[dMovAsistenciaCab]
                                               ([identidad]               
                                               ,[cod_tipo_solicitud]      
                                               ,[num_solicitud]           
                                               ,[cod_centroresp]          
                                               ,[idtrabajador]            
                                               ,[cod_subtipo_solicitud]   
                                               ,[fch_mov_solicitud]       
                                               ,[dsc_mov_solicitud]       
                                               ,[cod_solicitante]         
                                               ,[cod_estado]            
                                               ,[flg_automatico]        
                                               ,[flg_activo]            
                                               ,[fch_auditoria_reg]     
                                               ,[fch_auditoria_act]     
                                                )
                                         VALUES(
                                                @identidad
                                               ,@codtiposolicitud
                                               ,@nrosolicitud
                                               ,@centroresp
                                               ,@idtrabajador
                                               ,@codsubtipo
                                               ,@fecha_mov_solicitud
                                               ,@descripcion_solicitud
                                               ,@codempleado
                                               ,'REG'
                                               ,'NO'
                                               ,'SI'
                                               ,GETDATE()
                                               ,GETDATE()
                                                );
                            ";

            _logger.LogInformation("QUERY===>" + query);

            var result = await ServerUsReadDbConnection.QueryAsync<int>(query,
                                            new
                                            {

                                                identidad = insertDto.identidad,
                                                codtiposolicitud = insertDto.codtiposolicitud,
                                                nrosolicitud = insertDto.nrosolicitud,
                                                centroresp = insertDto.centroresp,
                                                idtrabajador = insertDto.idtrabajador,
                                                codsubtipo = insertDto.codsubtipo,
                                                fecha_mov_solicitud = insertDto.fecha_mov_solicitud,
                                                descripcion_solicitud = insertDto.descripcion_solicitud,
                                                codempleado = insertDto.idtrabajador.ToString("D6")
                                            });

            return result.Count;
        }


        public async Task<bool> InsertPermSP(ServerUsInsPermSPDto dto)
        {
            try
            {
                string sqlstore = string.Format("usp_efitec_regpermiso");

                var queryParameters = new DynamicParameters();
              


                queryParameters.Add("@ai_identidad"             , dto.ai_identidad              );       
                queryParameters.Add("@as_cod_tipo_solicitud"    , dto.as_cod_tipo_solicitud     );
                queryParameters.Add("@as_cod_centroresp"        , dto.as_cod_centroresp         );
                queryParameters.Add("@as_numero_documento"      , dto.as_numero_documento       );
                queryParameters.Add("@as_cod_subtipo_solicitud" , dto.as_cod_subtipo_solicitud  );
                queryParameters.Add("@adt_fch_movimiento"       , dto.adt_fch_movimiento        );
                queryParameters.Add("@adt_fch_horas_inicio"     , dto.adt_fch_horas_inicio      );
                queryParameters.Add("@adt_fch_horas_final"      , dto.adt_fch_horas_final       );
                queryParameters.Add("@adt_fch_hora_ini_real"    , dto.adt_fch_hora_ini_real     );
                queryParameters.Add("@adt_fch_hora_fin_real"    , dto.adt_fch_hora_fin_real);

                _logger.LogInformation("dto.ai_identidad                : "+ dto.ai_identidad);
                _logger.LogInformation("dto.as_cod_tipo_solicitud       : "+ dto.as_cod_tipo_solicitud);
                _logger.LogInformation("dto.as_cod_centroresp           : "+ dto.as_cod_centroresp);
                _logger.LogInformation("dto.as_numero_documento         : "+ dto.as_numero_documento);
                _logger.LogInformation("dto.as_cod_subtipo_solicitud    : "+ dto.as_cod_subtipo_solicitud);
                _logger.LogInformation("dto.adt_fch_movimiento          : "+ dto.adt_fch_movimiento);
                _logger.LogInformation("dto.adt_fch_horas_inicio        : "+ dto.adt_fch_horas_inicio);
                _logger.LogInformation("dto.adt_fch_horas_final         : "+ dto.adt_fch_horas_final);
                _logger.LogInformation("dto.adt_fch_hora_ini_real       : "+ dto.adt_fch_hora_ini_real);
                _logger.LogInformation("dto.adt_fch_hora_fin_real       : "+ dto.adt_fch_hora_fin_real);


                _logger.LogInformation("sqlstore=====>                   :   " + sqlstore);


                var listUSer = await ServerUsReadDbConnection.QueryAsync<object>(
                     sqlstore,
                     queryParameters, commandType: CommandType.StoredProcedure);

                _logger.LogInformation("Se ejecutó el procedimiento correctamente");
                return true;
            }
            catch (Exception ex)
            {
                
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
                return false;
            }

            
        }
    }
}
