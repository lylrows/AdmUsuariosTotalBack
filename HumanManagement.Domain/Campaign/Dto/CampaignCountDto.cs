using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class CampaignCountDto
    {
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }

        public decimal porcentaje0 { get; set; }
        public decimal porcentaje1 { get; set; }
        public decimal porcentaje2 { get; set; }
        public bool completedt0 { get; set; }
        public bool completedt1 { get; set; }
        public bool completedt2 { get; set; }
    }
}
