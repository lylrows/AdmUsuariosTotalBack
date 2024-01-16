using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationComputerSkillsDto
    {
        public int Id { get; set; }
        public int IdPostulant { get; set; }
        public int IdEvaluation { get; set; }
        public string Software { get; set; }
        public bool? LevelAvanzado { get; set; }
        public bool? LevelIntermedio { get; set; }
        public bool? LevelBasico { get; set; }
        public int? IdLevel { get; set; }
    }
}
