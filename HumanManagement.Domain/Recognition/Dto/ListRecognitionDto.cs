using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Recognition.Dto
{
    public class ListRecognitionDto
    {
        public int nid_recognition { get; set; }
        public int nid_person { get; set; }
        public string sfullname { get; set; }
        public string simg { get; set; }
        public string stitle { get; set; }
        public string sdescription { get; set; }
        public string sicon { get; set; }
        public int nid_state { get; set; }
        public DateTime dregister { get; set; }
        public bool bactive { get; set; }
        public string TimeAll { get; set; }
    }
}
