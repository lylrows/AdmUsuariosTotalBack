using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Recognition.Models
{
    public class Recognition : BaseModel.BaseModel
    {
        [Column("nid_recognition")]
        public int Id { get; set; }
        [Column("nid_person")]
        public int nid_person { get; set; }
        [Column("nid_state")]
        public int nid_state { get; set; }
        [Column("nid_recognizer")]
        public int nid_recognizer { get; set; }
        [Column("stitle")]
        public string stitle { get; set; }
        [Column("sdescription")]
        public string sdescription { get; set; }
        [Column("sicon")]
        public string sicon { get; set; }

    }
}
