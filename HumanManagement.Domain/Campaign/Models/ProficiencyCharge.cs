using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Models
{
    public class ProficiencyCharge : BaseModel.BaseModel
    {
        [Column("nid_charge")]
        public int IdCharge { get; set; }

        [Column("nid_proficiency")]
        public int IdProficiency { get; set; }
        [Column("nid_campaign")]
        public int IdCampaign { get; set; }
        [Column("nlevel")]
        public int? Level { get; set; }
        [Column("nweight")]
        public int? Weight { get; set; }

        

    }
}
