using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class SalaryConcept : BaseModel.BaseModel
    {
        [Column("scodconcept")]
        public string CodConcept { get; set; }
        [Column("salias")]
        public string Alias { get; set; }
        [Column("sconcept_type")]
        public string ConceptType { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }
        [Column("bismedicalrest")]
        public bool? IsMedicalRest { get; set; }
    }
}
