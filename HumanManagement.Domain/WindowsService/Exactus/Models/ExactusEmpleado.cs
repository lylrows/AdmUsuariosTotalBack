using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    public class ExactusEmpleado
    {
        [Key]
        [Column("EMPLEADO")]
        [StringLength(20)]
        public string EMPLEADO { get; set; }

        public int? DETALLE_DIR_HAB { get; set; }

        [Required]
        [StringLength(70)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(1)]
        public string SEXO { get; set; }

        [StringLength(4)]
        public string TIPO_SANGRE { get; set; }

        [Required]
        [StringLength(4)]
        public string ESTADO_EMPLEADO { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTIVO { get; set; }

        [StringLength(20)]
        public string IDENTIFICACION { get; set; }

        [StringLength(20)]
        public string PASAPORTE { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        public DateTime? FECHA_SALIDA { get; set; }

        [Required]
        [StringLength(10)]
        public string DEPARTAMENTO { get; set; }

        [Required]
        [StringLength(8)]
        public string PUESTO { get; set; }

        [Required]
        [StringLength(8)]
        public string PLAZA { get; set; }

        [Required]
        [StringLength(4)]
        public string NOMINA { get; set; }

        [Required]
        [StringLength(25)]
        public string CENTRO_COSTO { get; set; }

        public DateTime FECHA_NACIMIENTO { get; set; }

        [Required]
        [StringLength(8)]
        public string UBICACION { get; set; }

        [Required]
        [StringLength(4)]
        public string PAIS { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO_CIVIL { get; set; }

        public short? DEPENDIENTES { get; set; }

        [StringLength(20)]
        public string ASEGURADO { get; set; }

        [StringLength(4)]
        public string CLASE_SEGURO { get; set; }

        [StringLength(20)]
        public string PERMISO_CONDUCIR { get; set; }

        [StringLength(20)]
        public string PERMISO_SALUD { get; set; }

        [StringLength(20)]
        public string NIT { get; set; }

        public decimal VACS_PENDIENTES { get; set; }

        public DateTime VACS_ULT_CALCULO { get; set; }

        public DateTime? FECHA_PROX_EVAL { get; set; }

        public decimal SALARIO_REFERENCIA { get; set; }

        [Required]
        [StringLength(1)]
        public string FORMA_PAGO { get; set; }

        [StringLength(50)]
        public string CUENTA_ENTIDAD { get; set; }

        [StringLength(8)]
        public string ENTIDAD_FINANCIERA { get; set; }

        [Required]
        [StringLength(4)]
        public string HORARIO { get; set; }

        [Column(TypeName = "text")]
        public string DIRECCION_HAB { get; set; }

        [Column(TypeName = "text")]
        public string DIRECCION_POSTAL { get; set; }

        [StringLength(20)]
        public string TELEFONO1 { get; set; }

        [StringLength(40)]
        public string NOTAS_TEL1 { get; set; }

        [StringLength(20)]
        public string TELEFONO2 { get; set; }

        [StringLength(40)]
        public string NOTAS_TEL2 { get; set; }

        [StringLength(20)]
        public string TELEFONO3 { get; set; }

        [StringLength(40)]
        public string NOTAS_TEL3 { get; set; }

        [Column(TypeName = "image")]
        public byte[] FOTOGRAFIA { get; set; }

        [StringLength(40)]
        public string RUBRO1 { get; set; }

        [StringLength(40)]
        public string RUBRO2 { get; set; }

        [StringLength(40)]
        public string RUBRO3 { get; set; }

        [StringLength(40)]
        public string RUBRO4 { get; set; }

        [StringLength(40)]
        public string RUBRO5 { get; set; }

        [StringLength(40)]
        public string RUBRO6 { get; set; }

        [StringLength(40)]
        public string RUBRO7 { get; set; }

        [StringLength(40)]
        public string RUBRO8 { get; set; }

        [StringLength(40)]
        public string RUBRO9 { get; set; }

        [StringLength(40)]
        public string RUBRO10 { get; set; }

        [StringLength(40)]
        public string RUBRO11 { get; set; }

        [StringLength(40)]
        public string RUBRO12 { get; set; }

        [StringLength(40)]
        public string RUBRO13 { get; set; }

        [StringLength(40)]
        public string RUBRO14 { get; set; }

        [StringLength(40)]
        public string RUBRO15 { get; set; }

        public DateTime FECHA_NO_PAGO { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO_SALARIO_AUMEN { get; set; }

        public DateTime? FECHA_ANTIG_EMP { get; set; }

        public DateTime? FECHA_ANTIG_GOB { get; set; }

        public decimal? SALARIO_DIARIO_INT { get; set; }

        [StringLength(20)]
        public string PRIMER_APELLIDO { get; set; }

        [StringLength(20)]
        public string SEGUNDO_APELLIDO { get; set; }

        [StringLength(30)]
        public string NOMBRE_PILA { get; set; }

        [StringLength(249)]
        public string E_MAIL { get; set; }

        public int? DETALLE_DIR_POSTAL { get; set; }

        public decimal VACS_ADICIONALES { get; set; }

        [StringLength(40)]
        public string RUBRO16 { get; set; }

        [StringLength(40)]
        public string RUBRO17 { get; set; }

        [StringLength(40)]
        public string RUBRO18 { get; set; }

        [StringLength(40)]
        public string RUBRO19 { get; set; }

        [StringLength(40)]
        public string RUBRO20 { get; set; }

        [StringLength(40)]
        public string RUBRO21 { get; set; }

        [StringLength(40)]
        public string RUBRO22 { get; set; }

        [StringLength(40)]
        public string RUBRO23 { get; set; }

        [StringLength(40)]
        public string RUBRO24 { get; set; }

        [StringLength(40)]
        public string RUBRO25 { get; set; }

        public decimal? SALARIOPD_LOCAL { get; set; }

        public decimal? SALARIOPD_DOLAR { get; set; }

        public decimal? SALARIOPD_NOMINA { get; set; }

        public decimal? DIAS_DISP_INCAP { get; set; }

        [StringLength(25)]
        public string USUARIO_CREACION { get; set; }

        public DateTime? FECHA_HORA_CREACION { get; set; }

        [StringLength(25)]
        public string USUARIO_ULT_MOD { get; set; }

        public DateTime? FCH_HORA_ULT_MOD { get; set; }

        [StringLength(12)]
        public string TIPO_CUENTA_ENTIDAD { get; set; }

        [StringLength(50)]
        public string CTA_ELECTRONICA { get; set; }

        [StringLength(12)]
        public string DIVISION_GEOGRAFICA1 { get; set; }

        [StringLength(12)]
        public string DIVISION_GEOGRAFICA2 { get; set; }

        [StringLength(4)]
        public string PAIS_DIREC { get; set; }

        [StringLength(1)]
        public string TIPO_SALARIO { get; set; }

        [StringLength(2)]
        public string BENEFICIO_COLECTIVO { get; set; }

        public int? TIPO_MEDIDAS_CERTIFICADAS { get; set; }

        public int? TIPO_NIVEL_EDUCATIVO { get; set; }

        [StringLength(2)]
        public string U_TDEP { get; set; }

        [StringLength(3)]
        public string U_COD_SUCURSAL { get; set; }

        [StringLength(10)]
        public string U_TIPO_PLANILLA { get; set; }

        [StringLength(10)]
        public string TIPO_TRABAJADOR_NE { get; set; }

        [StringLength(10)]
        public string SUBTIPO_TRABAJADOR_NE { get; set; }

        [StringLength(10)]
        public string FORMA_PAGO_NE { get; set; }

        [StringLength(10)]
        public string MEDIO_PAGO_NE { get; set; }

        public byte NoteExistsFlag { get; set; }

        public DateTime RecordDate { get; set; }

        public Guid RowPointer { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(1)]
        public string INCREMENTO_PROG { get; set; }

        public DateTime? FECHA_ENTREGA_DOC { get; set; }

        [StringLength(4)]
        public string U_ENTSEGUROPRIV { get; set; }

        [StringLength(40)]
        public string U_DEPENEPS { get; set; }

        [StringLength(40)]
        public string U_DEPSEGPRI { get; set; }

        [StringLength(40)]
        public string U_ENTIDADEPS { get; set; }

        [StringLength(40)]
        public string U_ENTSEGVIDA { get; set; }

        public DateTime? U_FFINSEGPRI { get; set; }

        public DateTime? U_FINISEGPRI { get; set; }

        public DateTime? U_FINISEGVIDA { get; set; }

        [StringLength(40)]
        public string U_PLANEPS { get; set; }

        [StringLength(40)]
        public string U_PLANSEGPRI { get; set; }

        public decimal? U_SCTRPENSION { get; set; }

        public decimal? U_EPS { get; set; }

        public decimal? U_SCTRSALUD { get; set; }

        public decimal? U_SEGSALUDPRI { get; set; }

        [StringLength(40)]
        public string U_TIPOSEGDEPEN { get; set; }

        public int? U_NUMDEPEN { get; set; }

        [StringLength(40)]
        public string U_ENTSEGPRACT { get; set; }

        [StringLength(40)]
        public string U_DEPENDEPSHIJO { get; set; }

        [StringLength(40)]
        public string U_ENTIDADSCTR { get; set; }



        public string DEPARTAMENTO_DIR { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }
        public string DIRECCIONEMP { get; set; }




    }

    public class ExactusEmpleadoAcademico
    {
        public string EMPLEADO { get; set; }
        public string TIPO_ACADEMICO { get; set; }
        public string INSTITUCION { get; set; }
        public string CONCLUIDO { get; set; }
        public DateTime? FECHA_OBTENCION { get; set; }
        public DateTime? FECHA_VENCIMIENTO { get; set; }
        public string U_PROFESION { get; set; }
        public string TITULO { get; set; }

    }

    public class ExactusEmpleadoExperiencia
    {


        public string EMPLEADO { get; set; }
        public Int16 CONSECUTIVO { get; set; }
        public DateTime? FECHA_INGRESO { get; set; }
        public DateTime? FECHA_SALIDA { get; set; }
        public string EMPRESA { get; set; }
        public string PUESTO { get; set; }
        public string MOTIVO_SALIDA { get; set; }
        public string REFERENCIA { get; set; }
        public string TEL_REFERENCIA { get; set; }
        public string EMAIL_REFERENCIA { get; set; }
        public string FUNCIONES { get; set; }



    }

    public class ExactusEmpleadoFamilia
    {

        public string EMPLEADO { get; set; }
        public int CONSECUTIVO { get; set; }
        public string TIPO_DOC_ASEG { get; set; }
        public string IDENTIFICACION_ASE { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string IDENTIFICACION { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public DateTime? FECHA_NACIMIENTO { get; set; }
        public string SEXO { get; set; }
        public string VINCULO { get; set; }

    }

}
