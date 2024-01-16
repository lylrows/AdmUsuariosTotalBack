using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Dto
{
    public class SUInsertMovCabDto
    {
        public string codempleado { get; set; }
        public int identidad { get; set; }
        public string codtiposolicitud { get; set; }
        public int nrosolicitud { get; set; }
        public string centroresp { get; set; }
        public int idtrabajador { get; set; }
        public string codsubtipo { get; set; }
        public DateTime fecha_mov_solicitud { get; set; }
        public string descripcion_solicitud { get; set; }
    }
}
