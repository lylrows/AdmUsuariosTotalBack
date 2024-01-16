using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Utils.Dto
{
    public class ListChargerDto
    {
        public int nid_charge { get; set; }
        public string snamecharge { get; set; }
        public int nid_company { get; set; }
        public string sdescription { get; set; }
    }

    public class ListChargePostulantDto
    {
        public int nid_charge { get; set; }
        public int nid_area { get; set; }
        public int nid_company { get; set; }
        public string snamecharge { get; set; }
    }

}
