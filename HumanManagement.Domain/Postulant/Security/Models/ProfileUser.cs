using HumanManagement.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class ProfileUserPostulant
    {
        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("nid_user")]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual ProfilePostulant Profile { get; set; }
    }
}
