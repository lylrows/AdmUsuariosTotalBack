using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Areas.Dto
{
   public class AreasByUserDto
    {

        public int nid_area { get; set; }
        public int nid_person { get; set; }
        public int IdCompania { get; set; }
        public int IdSubArea { get; set; }
        public string SubArea { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public int IdGerencia { get; set; }
        public string Gerencia { get; set; }

    }
}
