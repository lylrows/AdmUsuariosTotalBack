using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Job.Models
{
    public class JobIdiom
    {
        [Column("nid_jobidiom")]
        public int Id { get; set; }

        [Column("nid_job")]
        public int IdJob { get; set; }

        [Column("nid_idiom")]
        public int IdIdiom { get; set; }

        [Column("nid_idiomlevel")]
        public int IdIdiomlevel { get; set; }
        public virtual Job Job { get; set; }
    }
}
