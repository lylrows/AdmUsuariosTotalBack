using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Models
{
    public class EvaluationMultitestExtern: BaseModel.BaseModel
    {
        [Column("nidevaluationmultitest")]
        public int Id { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nscoreintelligence")]
        public int? ScoreIntelligence { get; set; }

        [Column("nscoreaptitudverbal")]
        public int? ScoreAptitudVerbal { get; set; }

        [Column("nscoreaptitudnumerica")]
        public int? ScoreAptitudNumerica { get; set; }

        [Column("nscoreaptitudespacial")]
        public int? ScoreAptitudEspacial { get; set; }

        [Column("nscoreaptitudabstracta")]
        public int? ScoreAptitudAbstracta { get; set; }
    }
}
