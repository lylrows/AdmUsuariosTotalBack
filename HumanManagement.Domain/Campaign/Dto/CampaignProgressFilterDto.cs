using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class CampaignProgressFilterDto
    {
        public int IdCampaign { get; set; }
        public int numberAction { get; set; }
        public int statusEtapa { get; set; }
        public int CompanyId { get; set; }
        public int AreaId { get; set; }
        public int SubAreaId { get; set; }
        public int GerenciaId { get; set; }

    }
}
