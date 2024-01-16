using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    public class ExactusLiquidacionCab
    {
        public int LIQUIDACION { get; set; }
        public string EMPLEADO { get; set; }
        public string MONEDA { get; set; }
        public string ESTADO_LIQUIDAC { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public DateTime FECHA_SALIDA { get; set; }
        public string CERRAR_CONTRATOS { get; set; }
        public int NUMERO_ACCION { get; set; }
        public string FORMA_PAGO { get; set; }
        public string CUENTA_BANCO { get; set; }
        public decimal NUMERO_DOC_PAGO { get; set; }
        public string ASIENTO_CONTABLE { get; set; }
        public DateTime? FECHA_RETIRO_PAGO { get; set; }
        public string USUARIO_ULT_MODI { get; set; }
        public DateTime FECHA_ULT_MODI { get; set; }
        public string USUARIO_LIQUIDAC { get; set; }
        public DateTime? FECHA_LIQUIDACION { get; set; }

        public int SUBTIPODOC_PAGO { get; set; }
        public string PRESUPUESTO { get; set; }
        public string UNIDAD_OPERATIVA { get; set; }
        public int NUMERO_APARTADO { get; set; }
        public int NUMERO_EJERCIDO { get; set; }
        public string CALCULA_PAGO_NOMINA { get; set; }
        public string NOMINA_CALCULO { get; set; }
        public int NUMERO_NOMINA_CALCULO { get; set; }

        public string TIPO_EXTINCION_CONTRATO { get; set; }
        public string SITUACION_INAC { get; set; }

    }
}
