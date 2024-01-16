using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationProficiencyInternDto
    {
        public int? Id { get; set; }
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public string FullNamePostulant { get; set; }
        public int IdProficiency { get; set; }
        public string Proficiency { get; set; }
        public int? LevelRRHH { get; set; }
        public int? TestRRHH { get; set; }
        public string? ComentarioRRHH { get; set; }
        public int? LevelJefe { get; set; }
        public int? RowGroup { get; set; }
        public int? Expectative { get; set; }
        public int Flag { get; set; }
        public bool required { get; set; }
    }
}
