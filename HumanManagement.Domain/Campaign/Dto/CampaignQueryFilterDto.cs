

namespace HumanManagement.Domain.Campaign.Dto
{
    public class CampaignQueryFilterDto
    {

        public int nidCampana { get; set; }
        public string snamecampaign { get; set; }
        public int nstatus { get; set; }
        public int nyear { get; set; }
        public int nmonth { get; set; }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
    }

    public class CampaingByUserMyEvaluationFilter
    {
        public int nyear { get; set; }
        public int nidCampaing { get; set; }
        public int nidEmployee { get; set; }
        public int nidCompany { get; set; }
        public int etapa { get; set; }

    }

    public class CompanyByCampaingUserMyEvaluationFilter
    {
        public int nidCampaing { get; set; }
        public int nidEmployee { get; set; }
        

    }

    public class GerenciasByCampaingUserMyEvaluationFilter
    {
        public int nidCampaing { get; set; }
        public int nidEmployee { get; set; }
        public int nidCompany { get; set; }


    }

    public class AreasByCampaingUserMyEvaluationFilter
    {
        public int nidCampaing { get; set; }
        public int nidEmployee { get; set; }
        public int nidCompany { get; set; }
        public int nidGerencia { get; set; }


    }

    public class SubAreasByCampaingUserMyEvaluationFilter
    {
        public int nidCampaing { get; set; }
        public int nidEmployee { get; set; }
        public int nidCompany { get; set; }
        public int nidGerencia { get; set; }
        public int nidArea { get; set; }


    }

    public class CollaboratorsByCampaingUserMyEvaluationFilter
    {
        public int nidCampaing { get; set; }
        public int nidEmployee { get; set; }

    }

    public class ConfigDetailLevelNineBoxFilter
    {
        public int nid_campaing { get; set; }


    }
    public class CampaingByUserFilter
    {
        public int nidEmployee { get; set; }

    }
}
