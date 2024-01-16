using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Models
{
    public class SUMovAsistenciaDet
    {
        public int identidad { get; set; }
        public int num_solicitud { get; set; }
        public string cod_tipo_solicitud { get; set; }
        public int num_secuencia { get; set; }
        public string cod_subtipo_solicitud { get; set; }
        public DateTime fch_movimiento { get; set; }
        public decimal idtrabajador { get; set; }
        public DateTime fch_horas_inicio { get; set; }
        public DateTime fch_horas_final { get; set; }
        public DateTime fch_hora_ini_real { get; set; }
        public DateTime fch_hora_fin_real { get; set; }
        public string cod_estado { get; set; }
        public string flg_refrigerio { get; set; }
        public string flg_activo { get; set; }
        public DateTime fch_auditoria_reg { get; set; }
        public DateTime fch_auditoria_act { get; set; }
        public string cod_usuario_reg { get; set; }
        public string cod_usuario_act { get; set; }
        public string flg_lectora { get; set; }

    }
}
