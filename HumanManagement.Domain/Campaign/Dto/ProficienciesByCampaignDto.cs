using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class ProficienciesByCampaignDto
    {
        public int IdCharge { get; set; }
        public int IdProficiency { get; set; }
        public int IdCampaign { get; set; }
        public int? Level { get; set; }
        public int? Weight { get; set; }
        public string NameProficiency { get; set; }
    }
}
