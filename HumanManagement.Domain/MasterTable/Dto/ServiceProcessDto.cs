using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.MasterTable.Dto
{
    public class ServiceProcessDto
    {
        public string scode_service { get; set; }
        public int nsate { get; set; }
        public DateTime date_initial { get; set; }
        public DateTime date_end { get; set; }
    }
}
