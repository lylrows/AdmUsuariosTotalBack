using HumanManagement.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Security.Models
{
    public class ProfileApiAccess
    {
        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("nid_api_access")]
        public int IdApiAccess { get; set; }
        public virtual ApiAccess ApiAccess { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
