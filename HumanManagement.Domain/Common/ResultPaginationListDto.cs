using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Common
{
    public class ResultPaginationListDto<T>
    {
        public List<T> list { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }

    public class ResultLisExportDto<T>
    {
        public List<T> list { get; set; }
        
    }
}
