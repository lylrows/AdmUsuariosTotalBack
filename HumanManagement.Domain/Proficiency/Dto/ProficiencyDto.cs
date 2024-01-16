using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Proficiency.Dto
{
    public class ProficiencyDto
    {
        public int nid_proficiency { get; set; }
        public string sname { get; set; }
        public string sdescription { get; set; }
        public string slevel1 { get; set; }
        public string slevel2 { get; set; }
        public string slevel3 { get; set; }
        public string slevel4 { get; set; }
        public string sicon_proficiency { get; set; }
        public string background_color { get; set; }

    }
}
