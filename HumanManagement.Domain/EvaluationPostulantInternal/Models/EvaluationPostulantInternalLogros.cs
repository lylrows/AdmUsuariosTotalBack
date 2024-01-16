using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Models
{
    public class EvaluationPostulantInternalLogros: BaseModel.BaseModel
    {
        [Column("nid_evaluation")]
        public int Id { get; set; }

        [Column("nid_evaluation_postulant")]
        public int IdEvaluationPostulant { get; set; }

        [Column("scomments")]
        public string Comments { get; set; }
    }
}
