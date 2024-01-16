using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobOffersInternalPostulantDto
    {
        public int? Id { get; set; }
        public int IdJob { get; set; }
        public int IdPostulant { get; set; }
        public string CommentTimeWork { get; set; }
        public string CommentExperienceWork { get; set; }
        public string SalaryPreference { get; set; }
        public int? IdState { get; set; }
    }
}
