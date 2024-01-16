using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.JobObjective.Dto
{
    public class JobObjectiveDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
