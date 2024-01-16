using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class EvaluationListDto
    {
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
        public string NumberActionName { get; set; }
        
        public string IdentifEvaluated { get; set; }
        public string ImgEvaluated { get; set; }

        public string? Scommentdelete {get;set;}
    }

    public class CampaingEvaluationListDto
    {
        public int IdCampaign { get; set; }
        public string Campaign { get; set; }
    }

    public class CampaingByUserMyEvaluationDto
    {
        public int IdCampaign { get; set; }
        public string Campaign { get; set; }
    }

    public class CompanyByCampaingUserMyEvaluationDto
    {
        public int nid_company { get; set; }
        public string sdescription { get; set; }
    }

    public class GerenciasByCampaingUserMyEvaluationDto
    {
        public int nid_area { get; set; }
        public string snamearea { get; set; }
    }

    public class AreasByCampaingUserMyEvaluationDto
    {
        public int nid_area { get; set; }
        public string snamearea { get; set; }
    }

    public class SubAreasByCampaingUserMyEvaluationDto
    {
        public int nid_area { get; set; }
        public string snamearea { get; set; }
    }

    public class CollaboratorsByCampaingUserMyEvaluationDto
    {
        public int nid_person { get; set; }
        public string sfullname { get; set; }
    }

    public class CampaingByEvaluationDto
    {
        public int nid_campaign { get; set; }
        public string snamecampaign { get; set; }
    }

    public class ConfigLevelNineBoxDto
    {
        public int nid_config { get; set; }
        public int nid_group { get; set; }
        public string sdescription { get; set; }
        public int nmin_level { get; set; }
        public int nmax_level { get; set; }
        public bool bactive { get; set; }
        public string snamegroup { get; set; }
        public string scode_config { get; set; }

    }

}

