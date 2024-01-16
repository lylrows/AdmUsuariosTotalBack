using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Models
{
    public class EvaluationRatingPostulant: BaseModel.BaseModel
    {
		[Column("nidevaluationfortalezas")]
		public int Id { get; set; }

		[Column("nidevaluation")]
		public int IdEvaluation { get; set; }

		[Column("nidpostulant")]
		public int IdPostulant { get; set; }

		[Column("sratingrrhhstrengths")]
		public string SRatingrrhhstrengths { get; set; }

		[Column("sratingrrhhopportunities")]
		public string SRatingrrhhopportunities { get; set; }

		[Column("sratingjefestrengths")]
		public string SRatingjefestrengths { get; set; }

		[Column("sratingjefeopportunities")]
		public string SRatingjefeopportunities { get; set; }

		[Column("sratingclientstrengths")]
		public string SRatingclientstrengths { get; set; }

		[Column("sratingclientopportunities")]
		public string SRatingclientopportunities { get; set; }
	}
}
