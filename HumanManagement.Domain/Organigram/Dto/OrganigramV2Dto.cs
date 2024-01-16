using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Organigram.Dto
{
    public class OrganigramV2Dto
    {
        public int id { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int nid_area { get; set; }
        public string snamearea { get; set; }
        public string stags { get; set; }
        public string[] tags { get; set; }
        public string img { get; set; }
    }
}
