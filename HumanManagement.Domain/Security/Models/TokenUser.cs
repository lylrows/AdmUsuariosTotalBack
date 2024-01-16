using HumanManagement.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Security.Models
{
    public class TokenUser
    {
        [Column("nid_token")]
        public int Id { get; set; }

        [Column("nid_user")]
        public int IdUser { get; set; }

        [Column("stoken")]
        public string Token { get; set; }

        [Column("ntokenlife")]
        public int TokenLife { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("dupdate")]
        public DateTime DateUpdate { get; set; }
        public virtual User User { get; set; }

    }
}
