using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationFortalezasInternDto
    {
		public int? Id { get; set; }
		public int IdEvaluation { get; set; }
		public int IdPostulant { get; set; }
		public string FullNamePostulant { get; set; }
		public string SRatingrrhhstrengths { get; set; }
		public string SRatingrrhhopportunities { get; set; }
		public string SRatingjefestrengths { get; set; }
		public string SRatingjefeopportunities { get; set; }
	}
}
