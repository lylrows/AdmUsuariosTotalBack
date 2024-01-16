using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.BaseModel
{
    public class BaseModel
    {
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
    }
}
