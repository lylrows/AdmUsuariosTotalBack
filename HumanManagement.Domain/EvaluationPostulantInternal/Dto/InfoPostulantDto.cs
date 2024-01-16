using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class InfoPostulantDto
    {
        public PersonDto InformationPersonal { get; set; }
        public string SueldoPretendido { get; set; }
        public int IdEvaluation { get; set; }
        public bool? Approved { get; set; }
        public string StateEvaluation { get; set; }
        public FileDto FileMultitest { get; set; }
        public string Company { get; set; }
        public string ActualPosition { get; set; }
        public string ActualArea { get; set; }
        public DateTime DateRegister { get; set; }
        public int? Process { get; set; }
        public string PositionRequired { get; set; }
    }
}
