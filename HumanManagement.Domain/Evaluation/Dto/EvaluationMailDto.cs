using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class EvaluationMailDto
    {
        public string NameEvaluated { get; set; }
        public string Email { get; set; }
        public int IdEvaluation { get; set; }
        public string CampaignName { get; set; }
        public int PersonId { get; set; }
        public int AreaId { get; set; }
    }
}
