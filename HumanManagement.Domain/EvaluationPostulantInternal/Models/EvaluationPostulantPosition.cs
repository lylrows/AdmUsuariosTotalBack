using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Models
{
    public class EvaluationPostulantPosition: BaseModel.BaseModel
    {
        [Column("nid_evaluation")]
        public int Id { get; set; }

        [Column("nidevaluationpostulant")]
        public int IdEvaluationPostulant { get; set; }

        [Column("sevaluated")]
        public string Evaluated { get; set; }

        [Column("scompany")]
        public string Company { get; set; }

        [Column("sarea")]
        public string Area { get; set; }

        [Column("sactualposition")]
        public string ActualPosition { get; set; }

        [Column("spostulatedposition")]
        public string PostulatedPosition { get; set; }

        [Column("dadmissiondate")]
        public DateTime? DimissionDate { get; set; }

        [Column("stimeinoffice")]
        public string TimeInOffice { get; set; }

        [Column("spositionsincompany")]
        public string PositionsInCompany { get; set; }

    }
}
