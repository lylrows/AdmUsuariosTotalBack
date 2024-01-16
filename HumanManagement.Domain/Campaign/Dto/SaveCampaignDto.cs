using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class SaveCampaignDto
    {
        public int  nIdCampaign { get; set; }
        public string sNameCampaign { get; set; }

        public int nYear { get; set; }
        public int nMonth { get; set; }
        public string sStartDate { get; set; }
        public string sEndDate { get; set; }

        public List<AssignProficiencyDto> lstAssignProficiencies { get; set; }

    }
}
