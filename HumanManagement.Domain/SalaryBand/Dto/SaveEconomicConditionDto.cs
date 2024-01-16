using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class SaveEconomicConditionDto
    {
        public int currentPeriod { get; set; }
        public int previousPeriod { get; set; }
        public int monthPeriod { get; set; }
        public List<EcoConditionListDto> conditions { get; set; }
    }
}
