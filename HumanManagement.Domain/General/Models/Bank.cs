using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.General.Models
{
    public class Bank
    {
        [Column("nid_bank")]
        public int Id { get; set; }

        [Column("scodbank")]
        public string CodeBank { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sabbreviation")]
        public string Abbreviation { get; set; }

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
