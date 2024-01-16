using System;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Recruitment.QueryFilter
{
    public class RequestQueryFilter
    {
        public int State { get; set; }
        public int nidbussines { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public string scharge { get; set; }
        public int nidarea { get; set; }
        public int flat { get; set; }
        public int nid_applicant { get; set; }
        public int ntype_filter { get; set; }
        public int type { get; set; }
        public int nuserregister { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
    }
}
