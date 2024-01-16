using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    public class ExactusNomina
    {
        public int CONSECUTIVO { get; set; }
        public string EMPLEADO { get; set; }
        public string CONCEPTO { get; set; }
        public string NOMINA { get; set; }
        public Int16 NUMERO_NOMINA { get; set; }
        public string CENTRO_COSTO { get; set; }
        public decimal MONTO { get; set; }
        public decimal TOTAL { get; set; }
        public string TIPO_REGISTRO { get; set; }

    }
}
