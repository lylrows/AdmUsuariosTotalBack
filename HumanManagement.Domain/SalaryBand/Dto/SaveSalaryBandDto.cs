using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class SaveSalaryBandDto
    {
        public int idBandBox { get; set; }
        public string period { get; set; }
        public int idgroup { get; set; }
        public string points { get; set; }

        public string namegroup { get; set; }
        public string namecategory { get; set; }


        public decimal minimunpoint { get; set; }
        public decimal middlepoint { get; set; }
        public decimal maximunpoint { get; set; }
        public decimal bandwidth { get; set; }
        public bool active { get; set; }

    }
}
