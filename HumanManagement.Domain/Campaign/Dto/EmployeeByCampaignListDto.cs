using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class EmployeeByCampaignListDto
    {
        public int IdEmployee { get; set; }
        public string CodEmployee { get; set; }
        public int IdPosition { get; set; }
        public string PositionName { get; set; }
        public string AreaName { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }

    }
}
