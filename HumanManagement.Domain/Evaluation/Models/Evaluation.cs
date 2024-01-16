using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Evaluation.Models
{
    public class Evaluation : BaseModel.BaseModel
    {
        [Column("nid_evaluation")]
        public int IdEvaluation { get; set; }
        [Column("nid_campaign")]
        public int IdCampaign     { get; set; }
        [Column("ntime_part")]
        public int TimePart       { get; set; }
        [Column("nid_evaluator")]
        public int? IdEvaluator    { get; set; }
        [Column("nid_evaluated")]
        public int IdEvaluated    { get; set; }
        [Column("nnumberaction")]
        public int? NumberAction    { get; set; }
        [Column("bpendingapproval")]
        public bool? PendingApproval { get; set; }
        [Column("bisapproved0")]
        public bool? IsApproved0 { get; set; }
        [Column("sobservation0")]
        public string Observation0 { get; set; }
        [Column("bisapproved2")]
        public bool? IsApproved2 { get; set; }
        [Column("sobservation2")]
        public string Observation2 { get; set; }

        [Column("bisapproved1")]
        public bool? Approved1 { get; set; }

        [Column("sobservation1")]
        public string Observation1 { get; set; }
    }
}
