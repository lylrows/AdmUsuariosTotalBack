using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class StudientEmployeeDto
    {
		public int nid_education { get; set; }
		public int nid_employee { get; set; }
		public int nid_instruction { get; set; }
		public string sdescription_value { get; set; }
		public int nid_district { get; set; }
		public int nid_province { get; set; }
		public int nid_department { get; set; }
		public string sstudy_center { get; set; }
		public string scurrent_cycle { get; set; }
		public DateTime dateStart { get; set; }
		public DateTime? dateEnd { get; set; }
		public bool bactive { get; set; }
		public string nstate { get; set; }
		public string scarreer { get; set; }
	}
}
