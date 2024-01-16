using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class SalaryBandListDto
	{
        public int IdBandBox { get; set; }
        public int Period { get; set; }
        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public string CategoryName { get; set; }
        public string Points { get; set; }
        public decimal MinimunPoint { get; set; }
        public decimal MiddlePoint { get; set; }
        public decimal MaximunPoint { get; set; }
        public decimal BandhWidth { get; set; }
        public bool Active { get; set; }

        public int Positions { get; set; }
        public int People { get; set; }
        public int InBand { get; set; }
        public int Lower { get; set; }
        public int Higher { get; set; }

    }
}
