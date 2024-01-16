using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Recognition.Dto
{
    public class CreateRecognitionDto
    {

        public int nid_person { get; set; }
        public int nid_user { get; set; }
        public string stitle { get; set; }
        public string sdescription { get; set; }
        public string sicon { get; set; }
    }
}
