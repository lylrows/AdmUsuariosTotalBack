using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Mof.Dto
{
    public class MofDetailProfListDto
    {

        public int IdCharge { get; set; }
        public string NameCharge { get; set; }
        public int IdProficiency { get; set; }
        public string NameProficiency { get; set; }
        public int Weight { get; set; }
        public int Level { get; set; }
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public string ImageCompany { get; set; }
        public string NameArea { get; set; }

    }

    public class MofFilter
    {
        public int CompanyId {  get; set; }
        public int GerenciaId { get; set; }
        public int AreaId { get; set; }
        public int SubAreaId { get; set; }
    }
}
