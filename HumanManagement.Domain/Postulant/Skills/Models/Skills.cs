using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.Skills.Models
{
    public class Skills
    {
        [Column("nidskill")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sdescriptionskill")]
        public string DescriptionSkill { get; set; }
    }
}
