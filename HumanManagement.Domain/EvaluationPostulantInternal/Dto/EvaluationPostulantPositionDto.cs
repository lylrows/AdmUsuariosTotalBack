using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class EvaluationPostulantPositionDto
    {
        public int? Id { get; set; }
        public int IdEvaluationPostulant { get; set; }
        public string Evaluated { get; set; }
        public string Company { get; set; }
        public string Area { get; set; }
        public string ActualPosition { get; set; }
        public string PostulatedPosition { get; set; }
        public string DimissionDate { get; set; }
        public string TimeInOffice { get; set; }
        public string PositionsInCompany { get; set; }
        public List<PositionCompany> PositionsCompany { get; set; }
    }

    public class PositionCompany
    {
        public int IdEvaluationPostulant { get; set; } 
        public string scharge { get; set; }
        public string pstart { get; set; }
        public string pend { get; set; }
        public int months { get; set; }
        public string monthInit { get; set; }
        public string yearInit { get; set; }
        public string monthEnd { get; set; }
        public string yearEnd { get; set; }
        public int nuser { get; set; }
    }
}
