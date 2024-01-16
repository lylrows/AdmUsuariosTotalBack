using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class EvaluationExternTestDto
    {
        public int? Id { get; set; }
        public int IdEvaluationPostulant { get; set; }
        public string Test { get; set; }
        public string Score { get; set; }
        public string Expectativa { get; set; }
        public string FullNamePostulant { get; set; }
    }
}
