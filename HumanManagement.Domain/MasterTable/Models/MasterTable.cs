using System;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.MasterTable.Models
{
    public class MasterTable 
    {
        [Column("nid_mastertable")]
        public int Id { get; set; }

        [Column("nid_mastertable_type")]
        public int? IdType { get; set; }

        [Column("nid_father")]
        public int? IdFather { get; set; }

        [Column("sshort_value")]
        public string ShortValue { get; set; }

        [Column("sdescription_value")]
        public string DescriptionValue { get; set; }

        [Column("scomment")]
        public string Comment { get; set; }

        [Column("norder")]
        public int Order { get; set; }

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

        [Column("bbreak_requiredfile")]
        public bool BreakRequireFile { get; set; }

    }
}
