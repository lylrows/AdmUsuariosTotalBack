using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class EvaluationQueryDto
    {
        public int Id { get; set; }
        public int? Id_Company { get; set; }
        public int? Nidjob { get; set; }
        public string CodRequerimiento { get; set; }
        public string State { get; set; }
        public string PositionRequired { get; set; }
        public int? Process { get; set; }
        public List<EvaluationPostulantDto> postulantDtos { get; set; }
    }
}
