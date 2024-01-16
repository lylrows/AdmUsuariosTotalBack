using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationPostulantInternalLogrosDto
    {
        public int? Id { get; set; }
        public int IdEvaluationPostulant { get; set; }
        public string Comments { get; set; }
    }
}
