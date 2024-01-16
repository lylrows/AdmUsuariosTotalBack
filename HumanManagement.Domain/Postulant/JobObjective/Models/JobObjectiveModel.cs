using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.JobObjective.Models
{
    public class JobObjectiveModel: BaseModel.BaseModel
    {
        [Column("nidjobobjective")]
        public int Id { get; set; }

        [Column("nidperson")]
        public int IdPerson { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }
    }
}
