using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class ProficiencyByChargeFilterDto
    {
        public int nIdCampaign { get; set; }
        public int nIdCharge { get; set; }
        public int nFlagSearch { get; set; }
    }
}
