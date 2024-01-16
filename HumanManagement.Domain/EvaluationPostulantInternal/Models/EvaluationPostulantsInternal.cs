using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Models
{
    public class EvaluationPostulantsInternal: BaseModel.BaseModel
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

        [Column("sfolderfilemultitest")]
        public string FolderFileMultitest { get; set; }

    }
}
