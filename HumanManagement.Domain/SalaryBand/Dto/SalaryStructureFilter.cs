using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class SalaryStructureFilter
    {
        public int IdCompany { get; set; }
        public int Period { get; set; }
        public int IdArea { get; set; }
        public int IdCargo { get; set; }
        public string ChargeName { get; set; }
        public int Month { get; set; }

        public int IdGerencia { get; set; }
        public int IdSubArea { get; set; }
        public string AreaCC { get; set; }


    }
}
