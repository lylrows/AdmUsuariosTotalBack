using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    public class ExactusDepartamento
    {
		public string DEPARTAMENTO { get; set; }
		public string DESCRIPCION { get; set; }
		public string JEFE { get; set; }
		public string ACTIVO { get; set; }
		public byte NoteExistsFlag { get; set; }
		public DateTime RecordDate { get; set; }
		public Guid RowPointer { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime CreateDate { get; set; }
	}
	
}
