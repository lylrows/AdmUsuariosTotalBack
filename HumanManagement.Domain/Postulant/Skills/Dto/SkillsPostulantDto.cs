using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Skills.Dto
{
    public class SkillsPostulantDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string DescriptionSkill { get; set; }
        public bool Active { get; set; }
    }
}
