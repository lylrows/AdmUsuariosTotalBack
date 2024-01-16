using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSqlExactus.Repository
{
    public class ExactusEmpleadoRepository : IExactusEmpleadoRepository
    {
        private readonly IExactusReadDbConnection exactusReadDbConnection;
        private readonly ILogger<ExactusEmpleadoRepository> _logger;
        public IConfiguration Configuration { get; }
        public ExactusEmpleadoRepository(IExactusReadDbConnection exactusReadDbConnection, ILogger<ExactusEmpleadoRepository> _logger, IConfiguration configuration)
        {
            this.exactusReadDbConnection = exactusReadDbConnection;
            this._logger = _logger;
            Configuration = configuration;
        }

        public async Task<ExactusFullEmployeeDto> GetAll(ExactusEmpleadoFilterDto filterDto)
        {
            try
            {
                ExactusFullEmployeeDto oExactusFullEmployeeDto = new ExactusFullEmployeeDto();


                string storename = $"[{filterDto.Scheme}].[EFITEC_LEEREMPLEADOS]";

                var queryParameters = new DynamicParameters();

                var results = exactusReadDbConnection.QueryMultiple(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);
                

                var Empleados = results.Read<ExactusEmpleado>().ToList();
                var Academicos = results.Read<ExactusEmpleadoAcademico>().ToList();
                var Experiencias = results.Read<ExactusEmpleadoExperiencia>().ToList();
                var Familia = results.Read<ExactusEmpleadoFamilia>().ToList();

                oExactusFullEmployeeDto.Empleados = Empleados;
                oExactusFullEmployeeDto.Academicos = Academicos;
                oExactusFullEmployeeDto.Experiencias = Experiencias;
                oExactusFullEmployeeDto.Familia = Familia;


                return oExactusFullEmployeeDto;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al intentar ejecutar");
                _logger.LogError("[Import - ExactusEmpleadoRepository]-[Error: " + ex.Message);
                _logger.LogError("[Import - ExactusEmpleadoRepository]-[Error: " + ex.StackTrace);
            }
            return new ExactusFullEmployeeDto();

        }

        public async Task<bool> InsertEmpleado(ExactusEmpleadoInsertDto dto)
        {
            string query = @"
                                set dateformat dmy;
                                INSERT INTO [<SCHEMA>].[EMPLEADO]
                                   (
                                        [EMPLEADO],
                                        [NOMBRE],
                                        [SEXO],
                                        [ESTADO_EMPLEADO],
                                        [ACTIVO],
                                        [FECHA_INGRESO],
                                        [DEPARTAMENTO],
                                        [PUESTO],
                                        [PLAZA],
                                        [NOMINA],
                                        [CENTRO_COSTO],
                                        [FECHA_NACIMIENTO],
                                        [UBICACION],
                                        [PAIS],
                                        [ESTADO_CIVIL],
                                        [VACS_PENDIENTES],
                                        [VACS_ULT_CALCULO],
                                        [SALARIO_REFERENCIA],
                                        [FORMA_PAGO],
                                        [HORARIO],
                                        [FECHA_NO_PAGO],
                                        [TIPO_SALARIO_AUMEN],
                                        [VACS_ADICIONALES],
                                        [NoteExistsFlag],
                                        [RecordDate],
                                        [RowPointer],
                                        [CreatedBy],
                                        [UpdatedBy],
                                        [CreateDate],
                                        [DIRECCION_HAB]
                                    )
                                VALUES
                                   (@EMPLEADO,
                                    @NOMBRE,
                                    @SEXO,
                                    @ESTADO_EMPLEADO,
                                    @ACTIVO,
                                    @FECHA_INGRESO,
                                    @DEPARTAMENTO,
                                    @PUESTO,
                                    @PLAZA,
                                    @NOMINA,
                                    @CENTRO_COSTO,
                                    @FECHA_NACIMIENTO,
                                    @UBICACION,
                                    @PAIS,
                                    @ESTADO_CIVIL,
                                    @VACS_PENDIENTES,
                                    @VACS_ULT_CALCULO,
                                    @SALARIO_REFERENCIA,
                                    @FORMA_PAGO,
                                    @HORARIO,
                                    @FECHA_NO_PAGO,
                                    @TIPO_SALARIO_AUMEN,
                                    @VACS_ADICIONALES,
                                    @NoteExistsFlag,
                                    @RecordDate,
                                    @RowPointer,
                                    @CreatedBy,
                                    @UpdatedBy,
                                    @CreateDate,
                                    @DIRECCION_HAB

                                    )";

            query = query.Replace("<SCHEMA>", dto.Scheme);

            var result = await exactusReadDbConnection.QueryAsync<int>(query,
                                            new
                                            {
                                                EMPLEADO = dto.EMPLEADO,
                                                NOMBRE = dto.NOMBRE,
                                                SEXO = dto.SEXO,
                                                ESTADO_EMPLEADO = dto.ESTADO_EMPLEADO,
                                                ACTIVO = dto.ACTIVO,
                                                FECHA_INGRESO = dto.FECHA_INGRESO,
                                                DEPARTAMENTO = dto.DEPARTAMENTO,
                                                PUESTO = dto.PUESTO,
                                                PLAZA = dto.PLAZA,
                                                NOMINA = dto.NOMINA,
                                                CENTRO_COSTO = dto.CENTRO_COSTO,
                                                FECHA_NACIMIENTO = dto.FECHA_NACIMIENTO,
                                                UBICACION = dto.UBICACION,
                                                PAIS = dto.PAIS,
                                                ESTADO_CIVIL = dto.ESTADO_CIVIL,
                                                VACS_PENDIENTES = dto.VACS_PENDIENTES,
                                                VACS_ULT_CALCULO = dto.VACS_ULT_CALCULO,
                                                SALARIO_REFERENCIA = dto.SALARIO_REFERENCIA,
                                                FORMA_PAGO = dto.FORMA_PAGO,
                                                HORARIO = dto.HORARIO,
                                                FECHA_NO_PAGO = dto.FECHA_NO_PAGO,
                                                TIPO_SALARIO_AUMEN = dto.TIPO_SALARIO_AUMEN,
                                                VACS_ADICIONALES = dto.VACS_ADICIONALES,
                                                NoteExistsFlag = dto.NoteExistsFlag,
                                                RecordDate = dto.RecordDate,
                                                RowPointer = dto.RowPointer,
                                                CreatedBy = dto.CreatedBy,
                                                UpdatedBy = dto.UpdatedBy,
                                                CreateDate = dto.CreateDate,
                                                DIRECCION_HAB= dto.DIRECCION_HAB
                                            });

            return result.Count == 1;

        }



        public async Task<string> InsertEmpleadoSP(ExactusEmpleadoInsSpDto dto)
        {
            string sqlstore = string.Format( "{0}.EXACTUS_RH_EMPLEADO",dto.Schema);

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@PSCONJUNTO", dto.PSCONJUNTO);
            queryParameters.Add("@PSUSUARIO", dto.PSUSUARIO);
            queryParameters.Add("@PSEMPLEADO", dto.PSEMPLEADO);
            queryParameters.Add("@PSNOMBRE", dto.PSNOMBRE);
            queryParameters.Add("@PSPRIMERAPELLIDO", dto.PSPRIMERAPELLIDO);
            queryParameters.Add("@PSSEGUNDOAPELLIDO", dto.PSSEGUNDOAPELLIDO);
            queryParameters.Add("@PSNOMBREPILA", dto.PSNOMBREPILA);
            queryParameters.Add("@PSSEXO", dto.PSSEXO);
            queryParameters.Add("@PSTIPOSANGRE", dto.PSTIPOSANGRE);
            queryParameters.Add("@PSIDENTIFICACION", dto.PSIDENTIFICACION);
            queryParameters.Add("@PSPASAPORTE", dto.PSPASAPORTE);
            queryParameters.Add("@PDTFECHAINGRESO", dto.PDTFECHAINGRESO);
            queryParameters.Add("@PSDEPARTAMENTO", dto.PSDEPARTAMENTO);
            queryParameters.Add("@PSPUESTO", dto.PSPUESTO);
            queryParameters.Add("@PSPLAZA", dto.PSPLAZA);
            queryParameters.Add("@PSNOMINA", dto.PSNOMINA);
            queryParameters.Add("@PSCENTROCOSTO", dto.PSCENTROCOSTO);
            queryParameters.Add("@PDTFECHANACIMIENTO", dto.PDTFECHANACIMIENTO);
            queryParameters.Add("@PSUBICACION", dto.PSUBICACION);
            queryParameters.Add("@PSPAIS", dto.PSPAIS);
            queryParameters.Add("@PSESTADOCIVIL", dto.PSESTADOCIVIL);
            queryParameters.Add("@PNDEPENDIENTES", dto.PNDEPENDIENTES);
            queryParameters.Add("@PSASEGURADO", dto.PSASEGURADO);
            queryParameters.Add("@PSCLASESEGURO", dto.PSCLASESEGURO);
            queryParameters.Add("@PSPERMISOCONDUCIR", dto.PSPERMISOCONDUCIR);
            queryParameters.Add("@PSPERMISOSALUD", dto.PSPERMISOSALUD);
            queryParameters.Add("@PSNIT", dto.PSNIT);
            queryParameters.Add("@PNSALARIOREFERENCIA", dto.PNSALARIOREFERENCIA);
            queryParameters.Add("@PSCUENTAENTIDAD", dto.PSCUENTAENTIDAD);
            queryParameters.Add("@PSFORMAPAGO", dto.PSFORMAPAGO);
            queryParameters.Add("@PSENTIDADFINANCIERA", dto.PSENTIDADFINANCIERA);
            queryParameters.Add("@PSHORARIO", dto.PSHORARIO);
            queryParameters.Add("@PSTELEFONO1", dto.PSTELEFONO1);
            queryParameters.Add("@PSNOTASTEL1", dto.PSNOTASTEL1);
            queryParameters.Add("@PSTELEFONO2", dto.PSTELEFONO2);
            queryParameters.Add("@PSNOTASTEL2", dto.PSNOTASTEL2);
            queryParameters.Add("@PSTELEFONO3", dto.PSTELEFONO3);
            queryParameters.Add("@PSNOTASTEL3", dto.PSNOTASTEL3);
            queryParameters.Add("@PSEMAIL", dto.PSEMAIL);
            queryParameters.Add("@PDTFECHAANTIGEMP", dto.PDTFECHAANTIGEMP);
            queryParameters.Add("@PDTFECHAANTIGGOB", dto.PDTFECHAANTIGGOB);
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
            queryParameters.Add("@PSRUBRO11", dto.PSRUBRO11);
            queryParameters.Add("@PSRUBRO12", dto.PSRUBRO12);
            queryParameters.Add("@PSRUBRO13", dto.PSRUBRO13);
            queryParameters.Add("@PSRUBRO14", dto.PSRUBRO14);
            queryParameters.Add("@PSRUBRO15", dto.PSRUBRO15);
            queryParameters.Add("@PSRUBRO16", dto.PSRUBRO16);
            queryParameters.Add("@PSRUBRO17", dto.PSRUBRO17);
            queryParameters.Add("@PSRUBRO18", dto.PSRUBRO18);
            queryParameters.Add("@PSRUBRO19", dto.PSRUBRO19);
            queryParameters.Add("@PSRUBRO20", dto.PSRUBRO20);
            queryParameters.Add("@PSRUBRO21", dto.PSRUBRO21);
            queryParameters.Add("@PSRUBRO22", dto.PSRUBRO22);
            queryParameters.Add("@PSRUBRO23", dto.PSRUBRO23);
            queryParameters.Add("@PSRUBRO24", dto.PSRUBRO24);
            queryParameters.Add("@PSRUBRO25", dto.PSRUBRO25);
            queryParameters.Add("@PSNOTAS", dto.PSNOTAS);
            queryParameters.Add("@PNVACSADICIONALES", dto.PNVACSADICIONALES);
            
            queryParameters.Add("@PSMENSAJEERROR", "PRUEBA", DbType.String, direction: ParameterDirection.Output, 250);

            _logger.LogInformation("PROCEDURE: " + sqlstore);

            _logger.LogInformation("@PSCONJUNTO           :"+ dto.PSCONJUNTO);
            _logger.LogInformation("@PSUSUARIO            :"+ dto.PSUSUARIO);
            _logger.LogInformation("@PSEMPLEADO           :"+ dto.PSEMPLEADO);
            _logger.LogInformation("@PSNOMBRE             :"+ dto.PSNOMBRE);
            _logger.LogInformation("@PSPRIMERAPELLIDO     :"+ dto.PSPRIMERAPELLIDO);
            _logger.LogInformation("@PSSEGUNDOAPELLIDO    :"+ dto.PSSEGUNDOAPELLIDO);
            _logger.LogInformation("@PSNOMBREPILA         :"+ dto.PSNOMBREPILA);
            _logger.LogInformation("@PSSEXO               :"+ dto.PSSEXO);
            _logger.LogInformation("@PSTIPOSANGRE         :"+ dto.PSTIPOSANGRE);
            _logger.LogInformation("@PSIDENTIFICACION     :"+ dto.PSIDENTIFICACION);
            _logger.LogInformation("@PSPASAPORTE          :"+ dto.PSPASAPORTE);
            _logger.LogInformation("@PDTFECHAINGRESO      :"+ dto.PDTFECHAINGRESO);
            _logger.LogInformation("@PSDEPARTAMENTO       :"+ dto.PSDEPARTAMENTO);
            _logger.LogInformation("@PSPUESTO             :"+ dto.PSPUESTO);
            _logger.LogInformation("@PSPLAZA              :"+ dto.PSPLAZA);
            _logger.LogInformation("@PSNOMINA             :"+ dto.PSNOMINA);
            _logger.LogInformation("@PSCENTROCOSTO        :"+ dto.PSCENTROCOSTO);
            _logger.LogInformation("@PDTFECHANACIMIENTO   :"+ dto.PDTFECHANACIMIENTO);
            _logger.LogInformation("@PSUBICACION          :"+ dto.PSUBICACION);
            _logger.LogInformation("@PSPAIS               :"+ dto.PSPAIS);
            _logger.LogInformation("@PSESTADOCIVIL        :"+ dto.PSESTADOCIVIL);
            _logger.LogInformation("@PNDEPENDIENTES       :"+ dto.PNDEPENDIENTES);
            _logger.LogInformation("@PSASEGURADO          :"+ dto.PSASEGURADO);
            _logger.LogInformation("@PSCLASESEGURO        :"+ dto.PSCLASESEGURO);
            _logger.LogInformation("@PSPERMISOCONDUCIR    :"+ dto.PSPERMISOCONDUCIR);
            _logger.LogInformation("@PSPERMISOSALUD       :"+ dto.PSPERMISOSALUD);
            _logger.LogInformation("@PSNIT                :"+ dto.PSNIT);
            _logger.LogInformation("@PNSALARIOREFERENCIA  :"+ dto.PNSALARIOREFERENCIA);
            _logger.LogInformation("@PSCUENTAENTIDAD      :"+ dto.PSCUENTAENTIDAD);
            _logger.LogInformation("@PSFORMAPAGO          :"+ dto.PSFORMAPAGO);
            _logger.LogInformation("@PSENTIDADFINANCIERA  :"+ dto.PSENTIDADFINANCIERA);
            _logger.LogInformation("@PSHORARIO            :"+ dto.PSHORARIO);
            _logger.LogInformation("@PSTELEFONO1          :"+ dto.PSTELEFONO1);
            _logger.LogInformation("@PSNOTASTEL1          :"+ dto.PSNOTASTEL1);
            _logger.LogInformation("@PSTELEFONO2          :"+ dto.PSTELEFONO2);
            _logger.LogInformation("@PSNOTASTEL2          :"+ dto.PSNOTASTEL2);
            _logger.LogInformation("@PSTELEFONO3          :"+ dto.PSTELEFONO3);
            _logger.LogInformation("@PSNOTASTEL3          :"+ dto.PSNOTASTEL3);
            _logger.LogInformation("@PSEMAIL              :"+ dto.PSEMAIL);
            _logger.LogInformation("@PDTFECHAANTIGEMP     :"+ dto.PDTFECHAANTIGEMP);
            _logger.LogInformation("@PDTFECHAANTIGGOB     :"+ dto.PDTFECHAANTIGGOB);
            _logger.LogInformation("@PSRUBRO1             :"+ dto.PSRUBRO1);
            _logger.LogInformation("@PSRUBRO2             :"+ dto.PSRUBRO2);
            _logger.LogInformation("@PSRUBRO3             :"+ dto.PSRUBRO3);
            _logger.LogInformation("@PSRUBRO4             :"+ dto.PSRUBRO4);
            _logger.LogInformation("@PSRUBRO5             :"+ dto.PSRUBRO5);
            _logger.LogInformation("@PSRUBRO6             :"+ dto.PSRUBRO6);
            _logger.LogInformation("@PSRUBRO7             :"+ dto.PSRUBRO7);
            _logger.LogInformation("@PSRUBRO8             :"+ dto.PSRUBRO8);
            _logger.LogInformation("@PSRUBRO9             :"+ dto.PSRUBRO9);
            _logger.LogInformation("@PSRUBRO10            :"+ dto.PSRUBRO10);
            _logger.LogInformation("@PSRUBRO11            :"+ dto.PSRUBRO11);
            _logger.LogInformation("@PSRUBRO12            :"+ dto.PSRUBRO12);
            _logger.LogInformation("@PSRUBRO13            :"+ dto.PSRUBRO13);
            _logger.LogInformation("@PSRUBRO14            :"+ dto.PSRUBRO14);
            _logger.LogInformation("@PSRUBRO15            :"+ dto.PSRUBRO15);
            _logger.LogInformation("@PSRUBRO16            :"+ dto.PSRUBRO16);
            _logger.LogInformation("@PSRUBRO17            :"+ dto.PSRUBRO17);
            _logger.LogInformation("@PSRUBRO18            :"+ dto.PSRUBRO18);
            _logger.LogInformation("@PSRUBRO19            :"+ dto.PSRUBRO19);
            _logger.LogInformation("@PSRUBRO20            :"+ dto.PSRUBRO20);
            _logger.LogInformation("@PSRUBRO21            :"+ dto.PSRUBRO21);
            _logger.LogInformation("@PSRUBRO22            :"+ dto.PSRUBRO22);
            _logger.LogInformation("@PSRUBRO23            :"+ dto.PSRUBRO23);
            _logger.LogInformation("@PSRUBRO24            :"+ dto.PSRUBRO24);
            _logger.LogInformation("@PSRUBRO25            :"+ dto.PSRUBRO25);
            _logger.LogInformation("@PSNOTAS              :"+ dto.PSNOTAS);
            _logger.LogInformation("@PNVACSADICIONALES    :"+ dto.PNVACSADICIONALES);



            var listUSer = await exactusReadDbConnection.QueryAsync<object>(
                 sqlstore,
                 queryParameters, commandType: CommandType.StoredProcedure);

            string MENSAJEERROR = queryParameters.Get<string>("@PSMENSAJEERROR");
            _logger.LogInformation("@PSMENSAJEERROR    :" + MENSAJEERROR);

            return MENSAJEERROR;
        }

        public async Task<string> InsertDireccionSP(ExactusEmpleadoInsSpDirDto dto)
        {
            string sqlstore = string.Format("{0}.EXACTUS_RH_EMP_DIRECCION", dto.Schema);

            var queryParameters = new DynamicParameters();

            queryParameters.Add("@PSCONJUNTO", dto.PSCONJUNTO);
            queryParameters.Add("@PSUSUARIO", dto.PSUSUARIO);
            queryParameters.Add("@PSEMPLEADO", dto.PSEMPLEADO);
            queryParameters.Add("@PSTIPODIRECCION", dto.PSTIPODIRECCION);
            queryParameters.Add("@PSDIRECCION", dto.PSDIRECCION);
            queryParameters.Add("@PSCAMPO1",dto.PSCAMPO1);
            queryParameters.Add("@PSCAMPO2",dto.PSCAMPO2);
            queryParameters.Add("@PSCAMPO3",dto.PSCAMPO3);
            queryParameters.Add("@PSCAMPO4",dto.PSCAMPO4);
            queryParameters.Add("@PSCAMPO5",dto.PSCAMPO5);
            queryParameters.Add("@PSCAMPO6",dto.PSCAMPO6);
            queryParameters.Add("@PSCAMPO7",dto.PSCAMPO7);
            queryParameters.Add("@PSCAMPO8",dto.PSCAMPO8);
            queryParameters.Add("@PSCAMPO9", dto.PSCAMPO9);
            queryParameters.Add("@PSCAMPO10", dto.PSCAMPO10);


            _logger.LogInformation("PROCEDURE: " + sqlstore);
            _logger.LogInformation("@PSCONJUNTO         "+  dto.PSCONJUNTO);
            _logger.LogInformation("@PSUSUARIO          "+  dto.PSUSUARIO);
            _logger.LogInformation("@PSEMPLEADO         "+  dto.PSEMPLEADO);
            _logger.LogInformation("@PSTIPODIRECCION    "+  dto.PSTIPODIRECCION);
            _logger.LogInformation("@PSDIRECCION        "+  dto.PSDIRECCION);
            _logger.LogInformation("@PSCAMPO1           "+  dto.PSCAMPO1);
            _logger.LogInformation("@PSCAMPO2           "+  dto.PSCAMPO2);
            _logger.LogInformation("@PSCAMPO3           "+  dto.PSCAMPO3);
            _logger.LogInformation("@PSCAMPO4           "+  dto.PSCAMPO4);
            _logger.LogInformation("@PSCAMPO5           "+  dto.PSCAMPO5);
            _logger.LogInformation("@PSCAMPO6           "+  dto.PSCAMPO6);
            _logger.LogInformation("@PSCAMPO7           "+  dto.PSCAMPO7);
            _logger.LogInformation("@PSCAMPO8           "+  dto.PSCAMPO8);
            _logger.LogInformation("@PSCAMPO9           "+  dto.PSCAMPO9);
            _logger.LogInformation("@PSCAMPO10          "+  dto.PSCAMPO10);




            queryParameters.Add("@PSMENSAJEERROR", "PRUEBA", DbType.String, direction: ParameterDirection.Output, 250);

            var listUSer = await exactusReadDbConnection.QueryAsync<object>(
                 sqlstore,
                 queryParameters, commandType: CommandType.StoredProcedure);

            string MENSAJEERROR = queryParameters.Get<string>("@PSMENSAJEERROR");
            _logger.LogInformation("@PSMENSAJEERROR    :" + MENSAJEERROR);


            return MENSAJEERROR;
        }


        public async Task<List<ExactusEmpleadoTablaDto>> GetEmpleadoTabla(ExactusEmpleadoTablaFilterDto filterDto)
        {
            try
            {

                string storename = $"[{filterDto.Scheme}].[GrupoFeEmpleadoTablas]";

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@as_tabla", filterDto.TableName);

                var list = await exactusReadDbConnection.QueryAsync<ExactusEmpleadoTablaDto>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);

                return list.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al intentar ejecutar");
                _logger.LogError("[Import - ExactusEmpleadoRepository]-[Error: " + ex.Message);
                _logger.LogError("[Import - ExactusEmpleadoRepository]-[Error: " + ex.StackTrace);
            }
            return new List<ExactusEmpleadoTablaDto>();

        }


        public async Task<ExactusGlobalCCPDto> GetExactusGlobalCCP(string sschema)
        {
            try
            {

                string storename = $"[{sschema}].[EFITEC_GLOBALCCP]";

                var queryParameters = new DynamicParameters();
                
                var list = await exactusReadDbConnection.QueryAsync<ExactusGlobalCCPDto>(
                     storename,
                     queryParameters, commandType: CommandType.StoredProcedure);

                return list.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al intentar ejecutar");
                _logger.LogError("[Import - ExactusEmpleadoRepository]-[Error: " + ex.Message);
                _logger.LogError("[Import - ExactusEmpleadoRepository]-[Error: " + ex.StackTrace);
            }
            return new ExactusGlobalCCPDto ();
        }
    }
}
