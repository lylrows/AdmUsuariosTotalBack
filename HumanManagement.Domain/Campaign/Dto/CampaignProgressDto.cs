using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class CampaignProgressDto
    {
        public int RowNum { get; set; }
        public int IdEvaluation { get; set; }
        public int IdCampaign { get; set; }
        public string CampaignName { get; set; }
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
        public int IDGERENCIA { get; set; }
        public string GERENCIA { get; set; }
        public int IDAREA { get; set; }
        public string AREA { get; set; }
        public int IDSUBAREA { get; set; }
        public string SUBAREA { get; set; }
        public int AREACARGOEVALUADO { get; set; }
        public string numberActionName { get; set; }


        public string GERENCIA_BOSS { get; set; }
        public string AREA_BOSS { get; set; }
        public string SUBAREA_BOSS { get; set; }

    }
}
