using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationAditionalModel : BaseModel.BaseModel
    {
        [Column("nidinformationaditional")]
        public int Id { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("squestion1")]
        public string Question1 { get; set; }

        [Column("squestion2")]
        public string Question2 { get; set; }

        [Column("squestion3")]
        public string Question3 { get; set; }

        [Column("squestion4")]
        public string Question4 { get; set; }

        [Column("squestion5")]
        public string Question5 { get; set; }

        [Column("sespectativesalarial")]
        public string EspectativeSalary { get; set; }

        [Column("bbruto")]
        public bool? Bruto { get; set; }

        [Column("bneto")]
        public bool? Neto { get; set; }
    }
}
