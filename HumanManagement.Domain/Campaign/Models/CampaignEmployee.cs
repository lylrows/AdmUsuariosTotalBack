using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Models
{
    public class CampaignEmployee : BaseModel.BaseModel
    {
        [Column("nid_campaign")]
        public int IdCampaign { get; set; }
        [Column("nid_employee")]
        public int IdEmployee { get; set; }
        [Column("nid_charge")]
        public int IdCharge { get; set; }
    }

}
