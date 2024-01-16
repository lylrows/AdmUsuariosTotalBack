using HumanManagement.Domain.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Mof.Dto
{
    public class ProficiencyByChargeDto
    {
        public int IdCharge { get; set; }
        public string NameCharge { get; set; }
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public bool IsSelected { get; set; }
        public string ImageCompany { get; set; }
        public int IdArea { get; set; }
        public string NameArea { get; set; }

        public List <ProficiencyDetDto> Proficiencies { get; set; }
    }
    public class ProficiencyDetDto
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Level { get; set; }
        public bool IsConfigured { get; set; }
    }
}
