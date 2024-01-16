using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Cargo.QueryFilter
{
    public class CargoQueryFilter
    {
        public int IdCompany { get; set; }
        public int IdGerencia { get; set; }
        public int IdArea { get; set; }
        public int IdSubArea { get; set; }
        public string NombreCargo { get; set; }
        public string Estado { get; set; }
        public PaginationEntity Pagination { get; set; }
        public CargoQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }

    public class ChargesByCompanyAreaFilter
    {
        public int nidcompany { get; set; }
        public int nidgerencia { get; set; }
        public int nidarea { get; set; }
        public int nidsubarea { get; set; }


    }
    public class ChargesByCompanyAreaMultiFilter
    {
        public int nidcompany { get; set; }
        public int nidgerencia { get; set; }
        public string nidarea { get; set; }
        public string nidsubarea { get; set; }


    }
}
