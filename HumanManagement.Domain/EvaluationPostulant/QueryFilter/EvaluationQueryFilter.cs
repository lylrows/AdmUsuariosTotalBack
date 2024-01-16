using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.QueryFilter
{
    public class EvaluationQueryFilter
    {
        public int IdJob { get; set; }
        public PaginationEntity pagination { get; set; }
        public EvaluationQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }
}
