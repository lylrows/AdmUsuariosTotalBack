using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Job.Models
{
    public class JobKeyWords
    {
        [Column("nid_jobkeywords")]
        public int Id { get; set; }

        [Column("nid_job")]
        public int IdJob { get; set; }

        [Column("skeyword")]
        public string KeyWord { get; set; }

        public virtual Job Job { get; set; }
    }
}
