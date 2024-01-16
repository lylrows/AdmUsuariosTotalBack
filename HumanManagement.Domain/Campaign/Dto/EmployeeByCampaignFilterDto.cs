using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class EmployeeByCampaignFilterDto
    {
        public int nidCampana { get; set; }
        public int nidcompany { get; set; }
        public int nidgerencia { get; set; }
        public int nidArea { get; set; }
        public int nidsubarea { get; set; }
        public int nflagSearch { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }

        public string Dni { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
