using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Security.Models
{
    public class ProfileResource
    {
        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("nid_resource")]
        public int IdResource { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
