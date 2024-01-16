using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class CampaignListDto
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
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public decimal porcentaje0 { get; set; }
        public decimal porcentaje1 { get; set; }
        public decimal porcentaje2 { get; set; }
        public bool completedt0 { get; set; }
        public bool completedt1 { get; set; }
        public bool completedt2 { get; set; }
        public bool IsResetT0 { get; set; }
        public bool IsResetT1 { get; set; }
        public string MonthName { get; set; }
    }
}
