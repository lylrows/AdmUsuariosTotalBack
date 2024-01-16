using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class LiquidacionDetDto
    {
        public int nidcompany { get; set; }
        public int nliquidation { get; set; }
        public int nline { get; set; }
        public string sconcept { get; set; }
        public string sdescription { get; set; }
        public string stypeconcept { get; set; }
        public int nsequence { get; set; }
        public decimal nquantity { get; set; }
        public decimal namount { get; set; }
        public decimal ntotal_calc { get; set; }
        public string scentercost { get; set; }
        public string sledgeraccount { get; set; }

    }
}
