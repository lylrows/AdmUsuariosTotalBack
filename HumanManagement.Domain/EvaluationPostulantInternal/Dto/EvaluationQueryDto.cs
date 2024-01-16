using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationQueryDto
    {
        public int Id { get; set; }
        public string CodRequerimiento { get; set; }
        public string State { get; set; }
        public string PositionRequired { get; set; }
        public int? Process { get; set; }
        public List<EvaluationPostulantDto> postulantDtos { get; set; }
    }
}
