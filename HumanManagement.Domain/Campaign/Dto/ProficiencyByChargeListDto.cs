using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class ProficiencyByChargeListDto
    {
        public int IdProficiency { get; set; }
        public string NameProficiency { get; set; }
        public int Level { get; set; }
        public int Weight { get; set; }
    }

    public class GetCampaingBorrador
    {
        public int nid_campaign { get; set; }
        public string snamecampaign { get; set; }
        public int nid_evaluation { get; set; }
    }

    public class LastCampaignByEmployee
    {
        public int nid_campaign { get; set; }
    }
}
