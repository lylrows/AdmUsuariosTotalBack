using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Dto
{
    public class ExactusNominaFilterDto
    {
        public string Scheme { get; set; }
        public string arCodConcepts { get; set; }
        public string NominaCode { get; set; }
        public int NominaNumber { get; set; }
    }
}
