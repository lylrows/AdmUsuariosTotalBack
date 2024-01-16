using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Proficiency.Models
{
    public class Proficiency : BaseModel.BaseModel
    {
        [Column("nid_proficiency")]
        public int IdProficiency { get; set; }

        [Column("sname")]
        public string NameProficiency { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }
        [Column("slevel1")]
        public string Level1 { get; set; }
        [Column("slevel2")]
        public string Level2 { get; set; }
        [Column("slevel3")]
        public string Level3 { get; set; }
        [Column("slevel4")]
        public string Level4 { get; set; }
        [Column("sicon_proficiency")]
        public string IconProficiency { get; set; }
        [Column("brequired")]
        public bool Required { get; set; }

    }
}
