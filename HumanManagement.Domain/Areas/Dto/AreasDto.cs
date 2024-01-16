using HumanManagement.Domain.Areas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Areas.Dto
{
    public class AreasDto: Entity
    {
        public int Id { get; set; }
        public int? IdUpperArea { get; set; }
        public int IdEmpresa { get; set; }
        public string AreaPadre { get; set; }
        public string Empresa { get; set; }
        public string NameArea { get; set; }
        public bool Active { get; set; }
        public int State { get; set; }
        public string CodExactus { get; set; }
    }

    public class AreasComboDto
    {
        public int nid_area { get; set; }
        public int nidupperarea { get; set; }
        public string snamearea { get; set; }
        public int nid_company { get; set; }
        public string snamecompany { get; set; }
    }

    public class CompanyComboDto
    {
        public int nid_user { get; set; }
        public int nid_company { get; set; }
        public string sdescription { get; set; }
    }
}
