using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.NineBox.Models
{
    public class NineBox
    {
        [Column("nid_config")]
        public int Id { get; set; }
        [Column("nid_group")]
        public int IdGroup { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }
        [Column("nmin_level")]
        public int MinLevel { get; set; }
        [Column("nmax_level")]
        public int MaxLevel { get; set; }
        [Column("bactive")]
        public bool Active { get; set; }
        [Column("dregister")]
        public DateTime DateRegister { get; set; }
        [Column("nuserregister")]
        public int IdUserRegister { get; set; }
        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }
        [Column("nuserupdate")]
        public int? IdUserUpdate { get; set; }
        [Column("snamegroup")]
        public string NameGroup { get; set; }
        [Column("scode_config")]
        public string CodeConfig { get; set; }

    }
}
