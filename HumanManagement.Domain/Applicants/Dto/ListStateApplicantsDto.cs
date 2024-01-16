using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Applicants.Dto
{
    public class ListStateApplicantsDto
    {
        public int ncvsend { get; set; }
        public int ncvread { get; set; }
        public int ncvnoread { get; set; }
        public int nfinish { get; set; }
    }
}
