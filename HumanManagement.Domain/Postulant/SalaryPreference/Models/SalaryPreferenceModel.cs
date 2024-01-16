using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.SalaryPreference.Models
{
    public class SalaryPreferenceModel: BaseModel.BaseModel
    {
        [Column("nidsalarypreference")]
        public int Id { get; set; }

        [Column("nidperson")]
        public int IdPerson { get; set; }

        [Column("smonto")]
        public string Monto { get; set; }
    }
}
