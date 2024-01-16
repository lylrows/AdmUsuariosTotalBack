using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Models
{
    public class EvaluationVacantInternal: BaseModel.BaseModel
    {
        [Column("nidevaluation")]
        public int Id { get; set; }

        [Column("scodreq")]  
        public string CodRequerimiento { get; set; }

        [Column("nstate")]
        public int State { get; set; }

        [Column("spositionrequired")]
        public string PositionRequired { get; set; }

        [Column("nprocess")]
        public int? Process { get; set; }

        [Column("nidjob")]
        public int? IdJob { get; set; }
    }
}
