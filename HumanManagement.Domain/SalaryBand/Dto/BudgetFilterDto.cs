using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class BudgetFilterDto
    {
        public int Period { get; set; }
        public int PeriodVariation { get; set; }
        
        public int Month { get; set; }

        public int IdAreaGroup { get; set; }
        public string AreaCenterCosts { get; set; }
    
    }
}
