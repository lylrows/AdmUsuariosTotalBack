using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationMultitestInternDto
    {
        public int Id { get; set; }
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public string Postulant { get; set; }
        public int? ScoreIntelligence { get; set; }
        public int? ScoreAptitudVerbal { get; set; }
        public int? ScoreAptitudNumerica { get; set; }
        public int? ScoreAptitudEspacial { get; set; }
        public int? ScoreAptitudAbstracta { get; set; }
    }
}
