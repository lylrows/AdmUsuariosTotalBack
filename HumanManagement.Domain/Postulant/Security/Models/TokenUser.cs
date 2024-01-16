using HumanManagement.Domain.Postulant.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class TokenUserPostulant
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
        public virtual UserPostulant User { get; set; }

    }
}
