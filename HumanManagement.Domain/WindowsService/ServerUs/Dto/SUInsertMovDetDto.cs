using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Dto
{
    public class SUInsertMovDetDto
    {
        public string codempleado { get; set; }
        public int identidad { get; set; }
        public int num_solicitud { get; set; }
        public string cod_tipo_solicitud { get; set; }
        public string cod_subtipo_solicitud { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public decimal idtrabajador { get; set; }
        public DateTime fecha_hora_inicio { get; set; }
        public DateTime fecha_hora_final { get; set; }
        public DateTime fecha_hora_inicio_real { get; set; }
        public DateTime fecha_hora_final_real { get; set; }
    }
}
