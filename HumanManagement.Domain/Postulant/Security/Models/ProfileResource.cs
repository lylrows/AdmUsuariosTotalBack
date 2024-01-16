using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class ProfileResourcePostulant
    {
        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("nid_resource")]
        public int IdResource { get; set; }

        [Column("bactive")]
        public int Active { get; set; }
        public virtual ProfilePostulant Profile { get; set; }
        public virtual ResourcePostulant Resource { get; set; }
    }
}
