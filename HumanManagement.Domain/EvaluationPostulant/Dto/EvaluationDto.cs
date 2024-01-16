using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class EvaluationDto
    {
        public int? Id { get; set; }
        public string CodRequerimiento { get; set; }
        public int State { get; set; }
        public string PositionRequired { get; set; }
        public int? Process { get; set; }
        public int? IdJob { get; set; }
    }
}
