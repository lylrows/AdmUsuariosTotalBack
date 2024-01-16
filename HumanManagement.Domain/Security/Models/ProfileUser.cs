using HumanManagement.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Security.Models
{
    public class ProfileUser
    {
        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("nid_user")]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
