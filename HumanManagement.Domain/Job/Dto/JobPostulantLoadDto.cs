using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobPostulantLoadDto
    {
        public string Postulant { get; set; }
        public string Email { get; set; }
        public DateTime? DateAppliant { get; set; }
        public string ApplicationSource { get; set; }
    }
}
