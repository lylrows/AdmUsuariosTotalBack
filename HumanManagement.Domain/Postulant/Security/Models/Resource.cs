using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class ResourcePostulant
    {
        [Column("nid_resource")]
        public int Id { get; set; }

        [Column("nid_father")]
        public int IdFhater { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }

        [Column("ntyperesource")]
        public int TypeResource { get; set; }

        [Column("srouterlink")]
        public string RouterLink { get; set; }

        [Column("shtml")]
        public string Html { get; set; }

        [Column("svgicon")]
        public string VgIcon { get; set; }

        [Column("norder")]
        public int Order { get; set; }

        [Column("bactive")]
        public int Active { get; set; }
    }
}
