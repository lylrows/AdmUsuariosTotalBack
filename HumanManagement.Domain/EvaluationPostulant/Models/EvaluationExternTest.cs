using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Models
{
    public class EvaluationExternTest: BaseModel.BaseModel
    {
        [Column("nidevaluation")]
        public int Id { get; set; }

        [Column("nidevaluationpostulant")]
        public int IdEvaluationPostulant { get; set; }

        [Column("stest")]
        public string Test { get; set; }

        [Column("sscore")]
        public string Score { get; set; }

        [Column("sexpectativa")]
        public string Expectativa { get; set; }
    }
}
