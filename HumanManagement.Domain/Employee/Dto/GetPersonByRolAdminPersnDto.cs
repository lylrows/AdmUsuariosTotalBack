using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class GetPersonByRolAdminPersnDto
    {
        public int nid_person { get; set; }
        public string sfullname { get; set; }
        public int nid_area { get; set; }
    }
}
