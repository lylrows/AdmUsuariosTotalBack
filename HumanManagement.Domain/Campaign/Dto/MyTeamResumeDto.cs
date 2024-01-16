using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class MyTeamResumeDto
    {
        public int nid_campaign { get; set; }
        public int nid_charge { get; set; }
        public string snamecharge { get; set; }
        public int nid_proficiency { get; set; }
        public string nameproficiency { get; set; }
        public int levelrequired { get; set; }
    }

    public class MyTeamResumeCompDto
    {
        public int nid_campaign { get; set; }
        public string semployeename { get; set; }
        public int nid_proficiency { get; set; }
        public int nid_proficiencylevel { get; set; }
        public decimal? nqualification { get; set; }
        public int nid_position { get; set; }
        public int nid_employee { get; set; }

        public int IdCampaign { get; set; }
        public string Campaign { get; set; }
        public int nnumberaction { get; set; }

        public bool? isExpanded { get; set; }
        public int nid_charge { get; set; }
        public string snamecharge { get; set; }
        public int rowNum { get; set; }

        public int nid_evaluator { get; set; }
    }


    public class MyTeamResumeObjDto
    {
        public int nid_campaign { get; set; }
        public string snamecampaign { get; set; }
        public string semployeename { get; set; }
        public int ngoal { get; set; }
        public int nprogress { get; set; }
        public int nweight { get; set; }
        public int nnumberaction { get; set; }
    }

    public class MyTeamResumeListDto
    {
        public int RowNum { get; set; }
        public int IdEvaluation { get; set; }
        public int IdCampaign { get; set; }
        public string Campaign { get; set; }
        public int TimePart { get; set; }
        public string TimePartDescription { get; set; }
        public int IdEvaluator { get; set; }
        public string EvaluatorName { get; set; }
        public int IdChargeEvaluator { get; set; }
        public string ChargeEvaluator { get; set; }
        public int IdEvaluated { get; set; }
        public string EvaluatedName { get; set; }
        public int IdChargeEvaluated { get; set; }
        public int IdAreaEvaluated { get; set; }
        public string ChargeEvaluated { get; set; }
        public string AreaEvaluated { get; set; }
        public int NumberAction { get; set; }
        public string numberActionName { get; set; }

        public int nid_proficiency { get; set; }
        public int nid_proficiencylevel { get; set; }
        public int nqualification { get; set; }


    }
}
