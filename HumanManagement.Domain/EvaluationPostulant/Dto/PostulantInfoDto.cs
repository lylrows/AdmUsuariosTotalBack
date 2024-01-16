using HumanManagement.Domain.Postulant.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class PostulantInfoDto
    {
        public PersonDto InformationPersonal { get; set; }
        public string Especializacion { get; set; }
        public string Carreer { get; set; }
        public string StateEstudy { get; set; }
        public string Skills { get; set; }
        public string Idiomas { get; set; }
        public string YearExperience { get; set; }
        public string SueldoPretendido { get; set; }
        public int IdEvaluation { get; set; }
        public bool? Approved { get; set; }
        public string StateEvaluation { get; set; }
        public int? Process { get; set; }
        public int IdJob { get; set; }
        public FileDto FileMultitest { get; set; }
        public FileDto FileCompetencias { get; set; }

    }

    public class FileDto
    {
        public string NameFile { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
    }
}
