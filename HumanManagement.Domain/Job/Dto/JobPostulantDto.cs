using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobPostulantDto
    {
        public int Id_Job { get; set; }
        public int Id_Postulant { get; set; }
        public string ApplicationSource { get; set; }
        public string DateRegister { get; set; }
        public DateTime? DateApplicant { get; set; }
    }
}
