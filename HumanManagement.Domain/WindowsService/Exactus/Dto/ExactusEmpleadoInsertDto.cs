using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Dto
{
    public class ExactusEmpleadoInsertDto
    {


        public string Scheme { get; set; }
        public string EMPLEADO { get; set; }
        public string IDENTIFICACION { get; set; }
        public string NOMBRE { get; set; }
        public string SEXO { get; set; }
        public string ESTADO_EMPLEADO { get; set; }
        public string ACTIVO { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PUESTO { get; set; }
        public string PLAZA { get; set; }
        public string NOMINA { get; set; }
        public string CENTRO_COSTO { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public string UBICACION { get; set; }
        public string PAIS { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public decimal VACS_PENDIENTES { get; set; }
        public DateTime VACS_ULT_CALCULO { get; set; }
        public decimal SALARIO_REFERENCIA { get; set; }
        public string FORMA_PAGO { get; set; }
        public string HORARIO { get; set; }
        public DateTime FECHA_NO_PAGO { get; set; }
        public string TIPO_SALARIO_AUMEN { get; set; }
        public decimal VACS_ADICIONALES { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string DIRECCION_HAB { get; set; }

    }


}
