using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Models
{
    public class EvaluationPostulant: BaseModel.BaseModel
    {
        [Column("nidevaluationpostulant")]
        public int Id { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nstate")]
        public int State { get; set; }

        [Column("bapproved")]
        public bool? Approved { get; set; }

        [Column("sfolderfilecompetencias")]
        public string FolderFileCompetencias { get; set; }

        [Column("snamefilecompetencias")]
        public string NameFileCompetencias { get; set; }

        [Column("sfolderfilemultitest")]
        public string FolderFileMultitest { get; set; }

        [Column("snamefilemultitest")]
        public string NameFileMultitest { get; set; }
    }
}
