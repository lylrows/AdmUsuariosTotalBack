using System.Collections.Generic;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class UpdateEvaluationDetailDto
    {
        public int IdEvaluation { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsApproved { get; set; }
        public string Observation { get; set; }

        public List<UpdateEvaluationDetailRow> list_detail { get; set; }

    }


    public class UpdateEvaluationDetailRow 
    {
        public int IdEvaluationDetail { get; set; }
        public decimal Qualification { get; set; }
        public string ActionsToImprove { get; set; }
        public int Indicator { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JobObjectives { get; set; }
        public string IndicatorOrganizational { get; set; }
        public int Goal { get; set; }
        public string GoalString { get; set; }
        public int Weight { get; set; }
        public decimal Progress { get; set; }
    }
}
