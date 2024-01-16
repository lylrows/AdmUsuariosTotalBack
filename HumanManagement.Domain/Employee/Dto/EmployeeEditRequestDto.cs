using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class EmployeeEditRequestDto
    {
		public int nid_education { get; set; }
		public int nid_employee { get; set; }
		public int nid_instruction { get; set; }
		public int nid_district { get; set; }
		public string sstudy_center { get; set; }
		public string scurrent_cycle { get; set; }
		public DateTime dateStart { get; set; }
		public DateTime dateEnd { get; set; }
		public string scarreer { get; set; }

	}

	public class DeleteStudenEmployeeDto
    {
		public int nid_education { get; set; }
	}
}
