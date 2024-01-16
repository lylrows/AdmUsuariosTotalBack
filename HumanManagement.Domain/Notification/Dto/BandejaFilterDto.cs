using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Notification.Dto
{
    public class BandejaFilterDto
    {
        public string semisor { get; set; }
        public string ssubject { get; set; }
        public string sstartdate { get; set; }
        public string senddate { get; set; }
        public int niduser { get; set; }
    }
}
