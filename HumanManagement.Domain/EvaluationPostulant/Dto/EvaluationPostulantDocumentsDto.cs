using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class EvaluationPostulantDocumentsDto
    {
        public int? Id { get; set; }

        public int IdEvaluationPostulant { get; set; }
        public string FolderAntecedentes { get; set; }
        public string FolderCertificado { get; set; }
        public string NombreDocumento { get; set; }
        public int IdPostulant { get; set; }
        public FileDto FileAntecedentes { get; set; }
        public FileDto FileCertificado { get; set; }

    }
}
