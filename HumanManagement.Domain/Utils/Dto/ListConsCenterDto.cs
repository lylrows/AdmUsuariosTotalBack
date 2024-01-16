using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Utils.Dto
{
    public class ListConsCenterDto
    {
        public int nid_costcenter { get; set; }
        public string sname { get; set; }
        public string scodcostcenter { get; set; }
    }


    public class InfoExactusSendDto
    {
        public int nid_costcenter { get; set; }
        public string sname_costcenter { get; set; }
        public string scodcostcenter { get; set; }
        public int nid_sede { get; set; }
        public string scode_sede { get; set; }
    }

}
