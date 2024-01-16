using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.SalaryPreference.Dto
{
    public class SalaryPreferenceDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string Monto { get; set; }
        public bool Active { get; set; }
    }
}
