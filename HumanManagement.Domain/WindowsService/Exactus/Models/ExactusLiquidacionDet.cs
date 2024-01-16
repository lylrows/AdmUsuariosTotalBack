using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    public class ExactusLiquidacionDet
    {
        public int LIQUIDACION { get; set; }
        public int LINEA { get; set; }
        public string CONCEPTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string TIPO_CONCEPTO { get; set; }
        public int SECUENCIA { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal MONTO { get; set; }
        public decimal TOTAL_CALCULADO { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string CUENTA_CONTABLE { get; set; }

    }
}
