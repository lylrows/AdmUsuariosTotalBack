using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class EconomicCondition : BaseModel.BaseModel
    {
        [Column("nid_economic_conditions")]
        public int IdEconomicCondition { get; set; }
        [Column("nperiod")]
        public int Period { get; set; }
        [Column("nid_company")]
        public int IdCompany { get; set; }
        [Column("nid_employee")]
        public int IdEmployee { get; set; }
        [Column("nbasic_month")]
        public decimal BasicMonth { get; set; }
        [Column("nother_fixed_month")]
        public decimal OtherFixedMonth { get; set; }
        [Column("nvariable_month")]
        public decimal VariableMonth { get; set; }
        [Column("npassive")]
        public decimal Passive { get; set; }
        [Column("notherunpaid")]
        public decimal OtherUnpaid { get; set; }
        [Column("nannualbonus")]
        public decimal AnnualBonus { get; set; }
        [Column("nmonthlyincome")]
        public decimal MonthlyIncome { get; set; }
        [Column("nannualcost")]
        public decimal AnnualCost { get; set; }
        [Column("nincrease")]
        public decimal Increase { get; set; }
        [Column("nincrease_passive")]
        public decimal IncreasePassive { get; set; }
        [Column("variationmontlyincome")]
        public decimal? VariationMontlyIncome { get; set; }
        [Column("variationannualcost")]
        public decimal? VariationAnnualCost { get; set; }
        [Column("sindicator")]
        public string Indicator { get; set; }
        [Column("nmonth")]
        public int? Month { get; set; }


    }
}
