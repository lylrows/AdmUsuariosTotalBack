using System;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Home.QueryFilter
{
    public class DocumentQueryFilter
    {
        public int IdCompany { get; set; }
        public int IdCategory { get; set; }
        public int IdSubCategory { get; set; }
        public PaginationEntity Pagination { get; set; }
        public DocumentQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
