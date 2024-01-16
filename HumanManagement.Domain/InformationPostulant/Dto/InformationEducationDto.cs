using HumanManagement.Domain.Utils.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationEducationDto
    {
        public int? Id { get; set; }
        public string Instruction { get; set; }
        public int IdPostulant { get; set; }
        public int IdEvaluation { get; set; }
        public string City { get; set; }
        public string StudyCenter { get; set; }
        public string Speciality { get; set; }
        public string DateStart { get; set; }
        public string DateFinish { get; set; }
        public string Carrer { get; set; }
        public int IdInstruction { get; set; }
        public int CurrentCycle { get; set; }
        public bool IsNoConcluido { get; set; }
        public InformationFilesDto InformationFile { get; set; }
    }
}
