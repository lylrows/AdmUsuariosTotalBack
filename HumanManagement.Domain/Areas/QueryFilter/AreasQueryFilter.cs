using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Areas.QueryFilter
{
    public class AreasQueryFilter
    {
        public int IdCompany { get; set; }
        public string NombreArea { get; set; }
        public PaginationEntity Pagination { get; set; }
        public AreasQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }

    public class AreasComboQueryFilter
    {
        public int IdUser { get; set; }
        public int IdCompany { get; set; }
    }

    public class SubAreasComboQueryFilter
    {
        public int IdArea { get; set; }
    }
    public class SubAreasComboMultipleQueryFilter
    {
        public string IdArea { get; set; }
    }



    public class AreasEvaluationComboQueryFilter
    {
        public int IdUser { get; set; }
        public int IdArea { get; set; }
    }

    public class SubAreasEvaluationComboQueryFilter
    {
        public int IdUser { get; set; }
        public int IdArea { get; set; }
    }

    public class CompanyComboQueryFilter
    {
        public int IdUser { get; set; }
    }

    public class GerenciasComboQueryFilter
    {
        public int IdCompany { get; set; }
    }

    public class JefesQueryFilter
    {
        public int IdGerencia { get; set; }
        public int IdArea { get; set; }
        public int IdSubArea { get; set; }
    }
}
