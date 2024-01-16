using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.General.Models
{
    public class CoreParameter
    {
        [Column("nid_parameter")]
        public int Id { get; set; }

        [Column("saplication")]
        public string ApplicationName { get; set; }

        [Column("smodulo")]
        public string Module { get; set; }

        [Column("skey")]
        public string Key { get; set; }

        [Column("nvalue")]
        public int? ValueNumeric { get; set; }

        [Column("svalue")]
        public string ValueString { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int UserUpdate { get; set; }
    }
}
