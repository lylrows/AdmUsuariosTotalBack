using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class AssignEmployeeDto
    {
        public int IdCampaign { get; set; }
        public List<AssignEmployeeDetailDto> Employelist { get; set; }
    }
    public class AssignEmployeeDetailDto
    {
        public int IdEmployee { get; set; }
        public int IdPosition { get; set; }
        public bool Active { get; set; }
    }
}
