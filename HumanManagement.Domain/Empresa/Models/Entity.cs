using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Empresa.Models
{
    public class Entity
    {
        [Column("niduserregister")]
        public int IdUserRegister { get; set; }
        public int? IdUserUpdate { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
