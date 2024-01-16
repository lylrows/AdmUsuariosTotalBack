using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class InfoReportIntegradoDto
    {
        public List<EvaluationProficiencyDto> InfoEvaluationProficiency { get; set; }
        public List<EvaluationRatingPostulantDto> InfoEvaluationRating { get; set; }
        public List<EvaluationMultitestExternDto> InfoEvaluationMultitest { get; set; }
        public string PositionApplicant { get; set; }
    }
}
