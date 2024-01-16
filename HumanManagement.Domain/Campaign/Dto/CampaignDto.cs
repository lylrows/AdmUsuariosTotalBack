using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.Mof.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class CampaignDto
    {

        public int Id_Campaign { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CantidadColaboradores { get; set; }
        public string NameCampaign { get; set; }
        public string StatusName { get; set; }
        public bool IsEvaluationGenerated { get; set; }
        
        public   List< ProficiencyByChargeDto> PositionList { get; set; }
    }
}
