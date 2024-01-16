using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Home.Models
{
    public class Organization
    {
        [Column("nid_organization")]
        public int Id { get; set; }

        [Column("sfilename")]
        public string Filename { get; set; }

        [Column("sfilenamefolder")]
        public string Filenamefolder { get; set; }

        [Column("stitle")]
        public string Title { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? UserUpdate { get; set; }
    }
}
