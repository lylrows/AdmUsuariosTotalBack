using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Job.Models
{
    public class JobOffersInternalPostulant: BaseModel.BaseModel
    {
        [Column("nid_jobofferspostulant")]
        public int Id { get; set; }

        [Column("nid_joboffers")]
        public int IdJob { get; set; }

        [Column("nid_postulant")]
        public int IdPostulant { get; set; }

        [Column("scommenttimework")]
        public string CommentTimeWork { get; set; }

        [Column("scommentexperiencework")]
        public string CommentExperienceWork { get; set; }

        [Column("ssalarypreference")]
        public string SalaryPreference { get; set; }

        [Column("nid_state")]
        public int? IdState { get; set; }
    }
}
