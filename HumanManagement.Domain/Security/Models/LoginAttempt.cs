using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Security.Models
{
    public class LoginAttempt : BaseModel.BaseModel
    {
        [Column("nid_attempt")]
        public int Id { get; set; }

        [Column("nid_user")]
        public int IdUser { get; set; }

        [Column("nnumberattempts")]
        public int NumberAttempts { get; set; }
    }
}
