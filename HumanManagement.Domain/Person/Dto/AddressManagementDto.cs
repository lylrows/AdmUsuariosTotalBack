using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Person.Dto
{
    public class AddressManagementDto
    {
		public int nid_address { get; set; }
		public string saddress { get; set; }
		public int nid_district { get; set; }
		public bool state { get; set; }
		public int nid_person { get; set; }
		public int flat { get; set; }
	}
}
