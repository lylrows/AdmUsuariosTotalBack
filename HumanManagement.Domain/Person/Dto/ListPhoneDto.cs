using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Person.Dto
{
    public class ListPhoneDto
    {
        public int nid_phone { get; set; }
        public int nid_person { get; set; }
        public string phone { get; set; }
        public bool nstate { get; set; }
    }
}
