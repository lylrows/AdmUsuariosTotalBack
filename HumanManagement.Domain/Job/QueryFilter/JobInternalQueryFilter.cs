using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Job.QueryFilter
{
    public class JobInternalQueryFilter
    {
        public int IdEmpresa { get; set; }
        public int IdGerencia { get; set; }
        public int IdArea { get; set; }
        public int IdJobType { get; set; }
        public PaginationEntity pagination { get; set; }
        public JobInternalQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }
}
