using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class EvaluationDetailDto
    {
        public int IdEvaluationDetail { get; set; }
        public int IdGroup { get; set; }
        public int NumberAction { get; set; }
        public int IdProficiency { get; set; }
        public string OrganizationalProficiency { get; set; }
        public string ProficiencyDescription { get; set; }
        public int IdProficiencyLevel { get; set; }
        public string DefinitionLevel { get; set; }

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
        public string RegisterDateText { get; set; }

        public string DescriptionLevel1 { get; set; }
        public string DescriptionLevel2 { get; set; }
        public string DescriptionLevel3 { get; set; }
        public string DescriptionLevel4 { get; set; }

        public string Observation0 { get; set; }
        public string Observation1 { get; set; }
        public string Observation2 { get; set; }

    }

    
}
