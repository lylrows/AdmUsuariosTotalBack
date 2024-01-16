using System;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Home.QueryFilter
{
    public class SliderQueryFilter
    {
        public int IdType { get; set; }
        public PaginationEntity Pagination { get; set; }
        public SliderQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
