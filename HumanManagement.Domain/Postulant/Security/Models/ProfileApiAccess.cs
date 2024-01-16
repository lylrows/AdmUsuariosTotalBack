using HumanManagement.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class ProfileApiAccessPostulant
    {
        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("nid_api_access")]
        public int IdApiAccess { get; set; }
        public virtual ApiAccessPostulant ApiAccess { get; set; }
        public virtual ProfilePostulant Profile { get; set; }
    }
}
