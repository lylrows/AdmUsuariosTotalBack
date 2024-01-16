using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Job.Models
{
    public class JobOffersInternalCurriculum: BaseModel.BaseModel
    {
        [Column("nid_jobcurriculumpostulant")]
        public int Id { get; set; }

        [Column("nid_postulant")]
        public int IdPostulant { get; set; }

        [Column("sfoldercv")]
        public string SFolderCv { get; set; }

    }
}
