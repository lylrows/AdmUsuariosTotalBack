using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class LiquidacionCabDto
    {
        public int nidcompany { get; set; }
        public int nliquidation { get; set; }
        public string scodemployee { get; set; }
        public string scurrency { get; set; }
        public string sstateliquidation { get; set; }
        public DateTime ddate_in { get; set; }
        public DateTime ddate_out { get; set; }
        public string sclose_contracts { get; set; }
        public int nnumberaction { get; set; }
        public string spayway { get; set; }
        public string saccountbank { get; set; }
        public decimal snumber_document_pay { get; set; }
        public string saccountseat { get; set; }
        public DateTime? ddate_out_pay { get; set; }
        public string suser_liquidation { get; set; }
        public DateTime? ddate_liquidation { get; set; }
        public int nsubtypedoc_pay { get; set; }
        public string sbudget { get; set; }
        public string sunit_operative { get; set; }
        public int nnumber_apart { get; set; }
        public int nnumber_exercised { get; set; }
        public string scalc_pay_nomina { get; set; }
        public string snomina_calc { get; set; }
        public int nnumber_nomina_calc { get; set; }
        public string scontract_term_type { get; set; }
        public string ssituation_unac { get; set; }
        public int order_spin { get; set; }

    }
}
