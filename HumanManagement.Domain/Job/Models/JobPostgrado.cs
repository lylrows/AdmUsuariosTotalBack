using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Job.Models
{
    public class JobPostgrado
    {
        [Column("nid")]
        public int Id { get; set; }
        [Column("nid_jobs")]
        public int idjobs { get; set; }
        [Column("nid_request")]
        public int idrequest { get; set; }
        [Column("nidgrade")]
        public int idgrade { get; set; }
        [Column("scareer")]
        public string scareer { get; set; }
        [Column("sgrade")]
        public string sgrade { get; set; }
        public virtual Job Job { get; set; }
    }
}
