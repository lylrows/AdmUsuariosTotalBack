using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.QueryFilter
{
    public class EvaluationInternQueryFilter
    {
        public int IdJob { get; set; }
        public PaginationEntity pagination { get; set; }
        public EvaluationInternQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }
}
