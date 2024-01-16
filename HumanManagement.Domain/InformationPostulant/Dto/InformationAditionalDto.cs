using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationAditionalDto
    {
        public int? Id { get; set; }
        public int IdPostulant { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
        public string EspectativeSalary { get; set; }
        public bool? Bruto { get; set; }
        public bool? Neto { get; set; }
    }
}
