using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Applicants.Dto
{
    public class FilterApplicants
    {
        public int IdUser { get; set; }
        public bool order { get; set; }
        public int nid_state { get; set; }
        public int CurrentPage { get; set; }
    }
}
