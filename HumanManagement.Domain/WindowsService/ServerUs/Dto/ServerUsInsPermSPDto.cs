using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Dto
{
	public class ServerUsInsPermSPDto
	{
		public int ai_identidad { get; set; }
		public string as_cod_tipo_solicitud { get; set; }
		public string as_cod_centroresp { get; set; }
		public string as_numero_documento { get; set; }
		public string as_cod_subtipo_solicitud { get; set; }
		public DateTime adt_fch_movimiento { get; set; }
		public DateTime adt_fch_horas_inicio { get; set; }
		public DateTime adt_fch_horas_final { get; set; }
		public DateTime adt_fch_hora_ini_real { get; set; }
		public DateTime adt_fch_hora_fin_real { get; set; }
	}
}
