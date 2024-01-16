using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class LoginAttemptPostulant
    {
        [Column("nid_attempt")]
        public int Id { get; set; }

        [Column("nid_user")]
        public int IdUser { get; set; }

        [Column("nnumberattempts")]
        public int NumberAttempts { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }
        [Column("dregister")]
        public DateTime dregister { get; set; }

        [Column("nuserregister")]
        public int UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int UserUpdate { get; set; }
    }
}
