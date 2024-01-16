using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.NineBox.QueryFilter
{
    public class NineBoxQueryFilter
    {
        public PaginationEntity Pagination { get; set; }
        public NineBoxQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
