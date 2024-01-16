using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class EvaluationListDto
    {
        public int Id { get; set; }
        public string CodReq { get; set; }
        public string PositionRequired { get; set; }
        public DateTime DateRegister { get; set; }
        public string State { get; set; }
    }
}
