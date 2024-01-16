using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationPostulantInfoCurriculumDto
    {
        public int Id { get; set; }
        public int IdEvaluationPostulant { get; set; }

        public int IdDetail { get; set; }
        public string Detail { get; set; }
        public string Espectative { get; set; }
        public int? IdValidation { get; set; }
        public string Comments { get; set; }
    }
}
