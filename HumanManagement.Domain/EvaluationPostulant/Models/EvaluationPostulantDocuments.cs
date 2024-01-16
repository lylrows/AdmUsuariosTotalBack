using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Models
{
    public class EvaluationPostulantDocuments: BaseModel.BaseModel
    {
        [Column("nidevaluationpostulantdocument")]
        public int Id { get; set; }

        [Column("nidevaluationpostulant")]
        public int IdEvaluationPostulant { get; set; }

        [Column("sfolderantecedentes")]
        public string FolderAntecedentes { get; set; }

        [Column("sfoldercertificado")]
        public string FolderCertificado { get; set; }

    }
}
