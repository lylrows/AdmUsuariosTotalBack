using HumanManagement.Domain.Contracts.ServerUs;
using HumanManagement.Domain.WindowsService.ServerUs.Contracts;
using HumanManagement.Domain.WindowsService.ServerUs.Dto;

using System.Threading.Tasks;

namespace HumanManagement.MsSqlServerUs.Repository
{
    public class SUMovAsistenciaDetRepository : ISUMovAsistenciaDetRepository
    {
        private readonly IServerUsReadDbConnection ServerUsReadDbConnection;
        public SUMovAsistenciaDetRepository(IServerUsReadDbConnection ServerUsReadDbConnection)
        {
            this.ServerUsReadDbConnection = ServerUsReadDbConnection;
        }
        public async Task<int> Insert(SUInsertMovDetDto insertDto)
        {
            string query = @"
                                INSERT INTO [RCA].[dMovAsistenciaDet]
                                           ([identidad],[num_solicitud],[cod_tipo_solicitud],[num_secuencia],[cod_subtipo_solicitud],[fch_movimiento]
                                               ,[idtrabajador],[fch_horas_inicio],[fch_horas_final],[fch_hora_ini_real],[fch_hora_fin_real],[cod_estado]
                                               ,[flg_refrigerio],[flg_activo]
                                               ,[fch_auditoria_reg],[fch_auditoria_act],[flg_lectora])
                                     VALUES
                                           (
                                            @identidad
                                           ,@num_solicitud
                                           ,@cod_tipo_solicitud
                                           ,1
                                           ,@cod_subtipo_solicitud
                                           ,@fecha_movimiento
                                           ,@idtrabajador
                                           ,@fecha_hora_inicio
                                           ,@fecha_hora_final
                                           ,@fecha_hora_inicio_real
                                           ,@fecha_hora_final_real
                                           ,'REG'
                                           ,'NU'
                                           ,'SI'
                                           ,GETDATE()
                                           ,GETDATE()
                                           ,'NU'
                                          );
                            ";


            var result = await ServerUsReadDbConnection.QueryAsync<int>(query,
                                            new
                                            {

                                                identidad = insertDto.identidad,
                                                num_solicitud = insertDto.num_solicitud,
                                                cod_tipo_solicitud = insertDto.cod_tipo_solicitud,
                                                cod_subtipo_solicitud = insertDto.cod_subtipo_solicitud,
                                                fecha_movimiento = insertDto.fecha_movimiento,
                                                idtrabajador = insertDto.idtrabajador,
                                                fecha_hora_inicio = insertDto.fecha_hora_inicio,
                                                fecha_hora_final = insertDto.fecha_hora_final,
                                                fecha_hora_inicio_real = insertDto.fecha_hora_inicio_real,
                                                fecha_hora_final_real = insertDto.fecha_hora_final_real,

                                            });

            return result.Count;
        }
    }
}
