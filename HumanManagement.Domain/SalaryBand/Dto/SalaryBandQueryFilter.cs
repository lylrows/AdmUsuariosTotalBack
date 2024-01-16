using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Dto
{
    public class SalaryBandQueryFilter
    {
        public PaginationEntity Pagination { get; set; }
        public SalaryBandQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
