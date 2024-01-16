using System.Collections.Generic;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class MyTeamResumeFilterDto
    {

        public string nidCampana { get; set; }
        public int companyid { get; set; }
        public int gerenciaid { get; set; }
        public string areaid { get; set; }
        public string subareaid { get; set; }
        public string nidcargo { get; set; }
        public string list_employee { get; set; }
        public string etapas { get; set; }

        //Adicional solo para grafico
        public int isviewgraphic { get; set; }
        public int nid_employee { get; set; }
        public int nid_campaign { get; set; }
    }

    public class MyTeamDataLineDto
    {
        public List<decimal> value { get; set; }
        public string name { get; set; }
        public int nnumberaction { get; set; }
        public int nid_charge { get; set; }
        public int nid_campaign { get; set; }
        public string snamecampaign { get; set; }
    }

    public class MyTeamDataObjDto
    {
        public string name { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        
        public List<decimal> data { get; set; }
        public EmphasisDto emphasis { get; set; }
        public SeriesLabelDto label { get; set; }
        public int nnumberaction { get; set; }

        public MarkLineObj markLine { get; set; }
    }

    public class MarkLineObj
    {
        public LineStyleObj lineStyle { get; set; }
        public List<MarkLineDataObj> data { get; set; }

    }
    public class MarkLineDataObj
    {
        public string name { get; set; }
        public int xAxis { get; set; }
        public MarkLineLabelObj label { get; set; }

    }
    public class MarkLineLabelObj 
    {
        public string formatter { get; set; }
        public string position { get; set; }
    }

    public class LineStyleObj
    {
        public string color { get; set; }
    }

    public class EmphasisDto
    {
        public string focus { get; set; }
    }
    public class SeriesLabelDto
    {
        public bool show { get; set; }
        public string formatter { get; set; }
        public string position { get; set; }
    }

}
