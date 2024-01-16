using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Person.Dto
{
    public class ListAddressDto
    {
        public int nid_address { get; set; }
        public string saddress { get; set; }
        public int nid_district { get; set; }
        public string sdistrict { get; set; }
        public int nid_province { get; set; }
        public string sprovince { get; set; }
        public int nid_department { get; set; }
        public string sdepartament { get; set; }
        public bool state { get; set; }
    }
}
