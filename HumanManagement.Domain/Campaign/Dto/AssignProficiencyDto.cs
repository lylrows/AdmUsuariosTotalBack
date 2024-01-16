using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class AssignProficiencyDto
    {
        public int IdCampaign { get; set; }
        public int IdCharge { get; set; }
        public List<AssignProficiencyDetailDto> ProficiencyList { get; set; }
    }
    public class AssignProficiencyDetailDto
    {
        public int IdProficiency { get; set; }
        public bool Active { get; set; }
        public int Weight { get; set; }
        public int Level { get; set; }
    }
}
