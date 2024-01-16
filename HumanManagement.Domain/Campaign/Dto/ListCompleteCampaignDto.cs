using HumanManagement.Domain.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class ListCompleteCampaignDto
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
        public bool completedt0 { get; set; }
        public bool completedt1 { get; set; }
    }
}
