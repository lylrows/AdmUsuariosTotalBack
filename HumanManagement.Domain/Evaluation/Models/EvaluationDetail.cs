using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace HumanManagement.Domain.Evaluation.Models
{
    public class EvaluationDetail : BaseModel.BaseModel
    {
        [Column("nid_evaluation_detail")]
        public int IdEvaluationDetail { get; set; }
        [Column("nid_evaluation")]
        public int IdEvaluation { get; set; }
        [Column("nidgroup")]
        public int? IdGroup { get; set; }
        [Column("nid_proficiency")]
        public int? IdProficiency { get; set; }
        [Column("nid_proficiencylevel")]
        public int? IdProficiencyLevel { get; set; }
        [Column("nnumberaction")]
        public int? NumberOfAction { get; set; }
        [Column("nqualification")]
        public decimal? Qualification { get; set; }
        [Column("sactionstoimprove")]
        public string ActionsToImprove { get; set; }
        [Column("nidicator")]
        public int? Indicator { get; set; }
        [Column("dstartdate")]
        public DateTime? StartDate { get; set; }
        [Column("denddate")]
        public DateTime? EndDate { get; set; }
        [Column("sjobobjectives")]
        public string JobObjectives { get; set; }
        [Column("sindicator")]
        public string IndicatorOrganizational { get; set; }
        [Column("ngoal")]
        public Int64? Goal { get; set; }
        [Column("sgoal")]
        public string GoalString { get; set; }

        [Column("nweight")]
        public int? Weight { get; set; }
        [Column("nprogress")]
        public decimal? Progress { get; set; }

    }
}
