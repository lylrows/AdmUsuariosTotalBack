using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class EcoConditionListDto
    {
        public int IdEmployee { get; set; }
        public int IdCompany { get; set; }
        public string CodEmployee { get; set; }
        public string Colaborator { get; set; }
        public string Position { get; set; }
        public string AreaName { get; set; }
        public string ManagementName { get; set; }
        public string Condition { get; set; }
        public string AdmissionDate { get; set; }
        public int IdEconomicCondition { get; set; }
        public decimal BasicMonth { get; set; }
        public decimal OtherFixedMonth { get; set; }
        public decimal VariableMonth { get; set; }
        public decimal Passive { get; set; }
        public decimal OtherUnpaid { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal? VariationMontlyIncome { get; set; }
        public decimal AnnualBonus { get; set; }
        public decimal AnnualCost { get; set; }
        public decimal? VariationAnnualCost { get; set; }
        public decimal Increase         { get; set; }
        public decimal IncreasePassive { get; set; }

        public decimal Increase_ant { get; set; }
        public decimal IncreasePassive_ant { get; set; }


        public int PrevIdEconomicCondition { get; set; }
        public decimal PrevBasicMonth { get; set; }
        public decimal PrevOtherFixedMonth { get; set; }
        public decimal PrevVariableMonth { get; set; }
        public decimal PrevPassive { get; set; }
        public decimal PrevOtherUnpaid { get; set; }
        public decimal PrevMonthlyIncome { get; set; }
        public decimal PrevAnnualBonus { get; set; }
        public decimal PrevAnnualCost { get; set; }

        public string SpaceText { get; set; }

        public string Presupuestado { get; set; }

    }
}
