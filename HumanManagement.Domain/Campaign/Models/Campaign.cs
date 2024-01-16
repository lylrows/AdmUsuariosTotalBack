using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Models
{
    public class Campaign : BaseModel.BaseModel
    {
        [Column("nid_campaign")]
        public int Id_Campaign { get; set; }
        [Column("nyear")]
        public int Year { get; set; }
        [Column("nmonth")]
        public int Month { get; set; }
        [Column("snamecampaign")]
        public string NameCampaign { get; set; }
        [Column("dstartdate")]
        public DateTime? StartDate { get; set; }
        [Column("denddate")]
        public DateTime? EndDate { get; set; }
        [Column("nstatus")]
        public int Status { get; set; }
        [Column("bisevaluationgenerated")]
        public bool IsEvaluationGenerated { get; set; }

        [Column("bIsResetT0")]
        public bool IsResetT0 { get; set; }

        [Column("bIsResetT1")]
        public bool IsResetT1 { get; set; }
    }
}
