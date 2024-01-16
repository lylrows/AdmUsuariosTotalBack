using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Person.Dto
{
    public class PhoneManagementDto
    {
        public int nid_phone { get; set; }
        public int nid_person { get; set; }
        public string phone { get; set; }
        public int flat { get; set; }
    }
}
