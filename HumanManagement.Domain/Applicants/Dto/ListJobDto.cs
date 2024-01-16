using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Applicants.Dto
{
    public class ListJobDto
    {
		public int id_job { get; set; }
		public DateTime dregister { get; set; }
		public string stitle { get; set; }
		public int ncompanyid { get; set; }
		public string company { get; set; }
		public string snoticedetails { get; set; }
		public string slocation { get; set; }
		public decimal nsalary { get; set; }
		public string smodality { get; set; }
	}
}
