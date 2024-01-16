using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class EmployeFileDto
    {
		public int nid_employee_file { get; set; }
		public int nid_employee { get; set; }
		public int nvacationdays { get; set; }
		public int npendingvacations { get; set; }
		public bool bsalarycurrency { get; set; }
		public bool bctscurrency { get; set; }
		public bool bitsray { get; set; }
		public int nid_safeplan { get; set; }
		public bool bdoesnotapplyqta { get; set; }
		public bool bmixedafp { get; set; }
		public int nid_sctrpensionentity { get; set; }
		public int nid_afp { get; set; }
		public int id_epsplan { get; set; }
		public string slifelaw { get; set; }
		public int nFesaludPlan { get; set; }
		public int nInternPlan { get; set; }
	}
}
