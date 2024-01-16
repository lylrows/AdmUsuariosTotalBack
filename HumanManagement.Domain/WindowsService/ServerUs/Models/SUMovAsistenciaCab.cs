using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Models
{
    public class SUMovAsistenciaCab
    {
        public int identidad { get; set; }
        public string cod_tipo_solicitud { get; set; }
        public int num_solicitud { get; set; }
        public string cod_centroresp { get; set; }
        public int idtrabajador { get; set; }
        public string cod_subtipo_solicitud { get; set; }
        public DateTime fch_mov_solicitud { get; set; }
        public string dsc_mov_solicitud { get; set; }
        public string cod_solicitante { get; set; }
        public string dsl_observaciones { get; set; }
        public DateTime fch_ultima_modific { get; set; }
        public string cod_usuario { get; set; }
        public string cod_estado { get; set; }
        public string flg_automatico { get; set; }
        public string flg_activo { get; set; }
        public DateTime fch_auditoria_reg { get; set; }
        public DateTime fch_auditoria_act { get; set; }
        public string cod_usuario_reg { get; set; }
        public string cod_usuario_act { get; set; }

    }
}
