using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Utils.Dto
{
    public class CategoryEmploymentDto
    {
        public int nid_category { get; set; }
        public string sdescription { get; set; }
        public int ndays_expiration { get; set; }
    }
}
