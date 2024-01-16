using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Person.Dto
{
    public class PersonExactusDto
    {

        public int nid_person { get; set; }
        public string scodepayroll { get; set; }
        public string scodelocation { get; set; }
        public decimal? salaryref { get; set; }
        public string schedule { get; set; }
        public string sfinancialentitycode { get; set; }
        public string sentityaccount { get; set; }
        public string sorigincodbankrem { get; set; }
        public string sorigincodbankcts { get; set; }
        public string scodeafp { get; set; }
        public string ssalarycurrency { get; set; }
        public string sctscurrency { get; set; }
        public string scodbankcts { get; set; }
        public string sctsaccount { get; set; }
        public string sdoctypebcp { get; set; }
        public bool bintegralremuneration { get; set; }
        public bool bnodomiciliado { get; set; }
        public string stypesalaryaccount { get; set; }
        public bool bfifthdiscount { get; set; }
        public bool bafpmixed { get; set; }
        public string sbloodtype { get; set; }
        public bool? bisonexactus { get; set; }
        public string dincomecountry { get; set; }
        public string scuspp { get; set; }
        public string dendposition { get; set; }
        public string dstartposition { get; set; }

    }
}
