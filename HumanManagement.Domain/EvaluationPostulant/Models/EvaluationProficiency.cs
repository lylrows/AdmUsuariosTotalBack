using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Models
{
    public class EvaluationProficiency
    {
        [Column("nidevaluationcompetencies")]
        public int Id { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nid_proficiency")]
        public int IdProficiency { get; set; }

        [Column("nlevelrrrhh")]
        public int? LevelRRHH { get; set; }

        [Column("nlevelclient")]
        public int? LevelClient { get; set; }

        [Column("nleveljefe")]
        public int? LevelJefe { get; set; }

        [Column("nrowgroup")]
        public int? RowGroup { get; set; }

        [Column("nespectative")]
        public int? Expectative { get; set; }
    }
}
