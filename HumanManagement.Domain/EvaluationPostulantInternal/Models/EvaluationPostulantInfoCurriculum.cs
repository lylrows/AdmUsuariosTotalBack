using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Models
{
    public class EvaluationPostulantInfoCurriculum: BaseModel.BaseModel
    {
        [Column("nid_evaluation")]
        public int Id { get; set; }

        [Column("nidevaluationpostulant")]
        public int IdEvaluationPostulant { get; set; }

        [Column("niddetail")]
        public int IdDetail { get; set; }

        [Column("sespectative")]
        public string Espectative { get; set; }

        [Column("nidvalidation")]
        public int? IdValidation { get; set; }

        [Column("scomments")]
        public string Comments { get; set; }
    }
}
