using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Models
{
    public class NotesEvaluationInternal: BaseModel.BaseModel
    {
        [Column("nidnotesevaluationpostulant")]
        public int Id { get; set; }

        [Column("nidevaluationpostulant")]
        public int IdEvaluationPostulant { get; set; }

        [Column("sdescripcion")]
        public string Descripcion { get; set; }

        [Column("sautor")]
        public string Autor { get; set; }
    }
}
