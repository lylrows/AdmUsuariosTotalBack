using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class BudgetListDto
    {

        public int IdAreaGroup { get; set; }
        public string NameGroup { get; set; }
        public int IdArea { get; set; }
        public string NameArea { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal PreviousAmount { get; set; }
        public bool IsGroup { get; set; }

        public decimal CurrentExecAmount { get; set; }
        public decimal PreviousExecAmount { get; set; }
        public decimal PreviousExecAmount1 { get; set; }
        public decimal PreviousExecAmount2 { get; set; }

        public decimal VariationPorc { get; set; }
        public decimal VariationAmount { get; set; }

    }
}
