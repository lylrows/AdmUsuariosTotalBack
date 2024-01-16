using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Job.QueryFilter
{
    public class JobQueryFilter
    {
        public int IdUser { get; set; }
        public string Type { get; set; }
        public PaginationEntity pagination { get; set; }
        public JobQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }
}
