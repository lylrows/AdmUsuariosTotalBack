using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.NineBox.Dto
{
    public class ListNineBoxDto
    {
        public int nid_config { get; set; }
        public int nid_group { get; set; }
        public string sdescription { get; set; }
        public int nmin_level { get; set; }
        public int nmax_level { get; set; }
        public bool bactive { get; set; }
        public string snamegroup { get; set; }
        public string scode_config { get; set; }
    }
}
