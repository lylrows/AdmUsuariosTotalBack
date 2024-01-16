using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.Skills.Models
{
    public class SkillsPostulant: BaseModel.BaseModel
    {
        [Column("nidskill")]
        public int Id { get; set; }

        [Column("nidperson")]
        public int IdPerson { get; set; }

        [Column("sdescriptionskill")]
        public string DescriptionSkill { get; set; }
    }
}
