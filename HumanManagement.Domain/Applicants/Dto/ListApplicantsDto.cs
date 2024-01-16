using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Applicants.Dto
{
    public class ListApplicantsDto
    {
		public int id_job { get; set; }
		public string stitle { get; set; }
		public string sjob_type { get; set; }
		public string smodality { get; set; }
		public string slocation { get; set; }
		public decimal nsalary { get; set; }
		public DateTime ddatepublication { get; set; }
		public DateTime ddatepostulation { get; set; }
		public int ncompanyid { get; set; }
		public string sdescription { get; set; }
		public int nid_state { get; set; }
		public string sdescription_value { get; set; }

		public string scompanyimageurl { get; set; }
	}
}
