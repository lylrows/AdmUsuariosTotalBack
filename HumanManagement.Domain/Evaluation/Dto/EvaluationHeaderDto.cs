using System;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class EvaluationHeaderDto
    {
        public int IdEvaluation { get; set; }
        public int IdCampaign { get; set; }
        public int TimePart { get; set; }
        public int? IdEvaluator { get; set; }
        public string EvaluatorName { get; set; }
        public string EvaluatorDNI { get; set; }
        public int IdEvaluated { get; set; }
        public string EvaluatedName { get; set; }
        public string EvaluatedDNI { get; set; }
        public string ChargeName { get; set; }
        public string Period { get; set; }
        public string AdmissionDate { get; set; }
        public string AreaName { get; set; }
        public int NumberAction { get; set; }
        public bool PendingApproval { get; set; }
        public bool IsApproved0 { get; set; }
        public string Observation0 { get; set; }
        public bool IsApproved2 { get; set; }
        public string Observation2 { get; set; }
        public bool IsApproved1 { get; set; }
        public string Observation1 { get; set; }

        public int IdUserEvaluated { get; set; }
        public int IdUserEvaluator { get; set; }
        public DateTime EndDate { get; set; }

        public int nid_company { get; set; }
        public string snamecompany { get; set; }
        public string scharge_company { get; set; }


    }
}
