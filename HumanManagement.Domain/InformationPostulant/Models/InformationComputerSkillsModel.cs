using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationComputerSkillsModel: BaseModel.BaseModel
    {
        [Column("nidcomputerskills")]
        public int Id { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("ssoftware")]
        public string Software { get; set; }

        [Column("blevelavanzado")]
        public bool? LevelAvanzado { get; set; }

        [Column("blevelintermedio")]
        public bool? LevelIntermedio { get; set; }

        [Column("blevelbasico")]
        public bool? LevelBasico { get; set; }

        [Column("nidlevel")]
        public int? IdLevel { get; set; }
    }
}
