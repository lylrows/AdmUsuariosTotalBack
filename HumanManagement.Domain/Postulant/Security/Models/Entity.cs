using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class Entity
    {
        [Column("niduserregister")]
        public int IdUserRegister { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
