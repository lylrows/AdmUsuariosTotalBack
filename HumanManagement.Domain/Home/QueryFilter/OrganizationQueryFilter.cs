using System;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Home.QueryFilter
{
    public class OrganizationQueryFilter
    {
        public string Description { get; set; }
        public PaginationEntity Pagination { get; set; }
        public OrganizationQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
