using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class InfoReportIntegradoInternDto
    {
        public List<EvaluationProficiencyInternDto> InfoEvaluationProficiency { get; set; }
        public List<EvaluationFortalezasInternDto> InfoEvaluationRating { get; set; }
        public List<EvaluationMultitestInternDto> InfoEvaluationMultitest { get; set; }
        public string PositionApplicant { get; set; }
    }
}
