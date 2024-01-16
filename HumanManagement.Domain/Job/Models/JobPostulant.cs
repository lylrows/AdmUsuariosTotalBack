using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Models
{
    public class JobPostulant : BaseModel.BaseModel
    {
        [Column("nidjob")]
        public int Id_Job { get; set; }

        [Column("nidpostulant")]
        public int Id_Postulant { get; set; }

        [Column("nid_state")]
        public int? IdState { get; set; }

        [Column("napplicationsource")]
        public int? ApplicationSource { get; set; }

        [Column("dapplicant")]
        public DateTime? DateApplicant { get; set; }
    }
}
