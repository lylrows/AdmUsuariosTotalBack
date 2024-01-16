using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class EmployeeChargeDto
    {
        public int IdApplicant { get; set; }
        public string NameApplicant { get; set; }
        public int IdCompany { get; set; }
        public string Company { get; set; }
        public string PositionApplicant { get; set; }
        public int IdArea { get; set; }
        public string NameArea { get; set; }
        public int IdGerencia { get; set; }
    }
}
