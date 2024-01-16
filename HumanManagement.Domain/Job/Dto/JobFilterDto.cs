using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobFilterDto
    {
        public List<int> Companys { get; set; }
        public List<int> CreationDates { get; set; }
        public List<int> JobTypes { get; set; }
        public List<int> WorkTypes { get; set; }
        public List<string> Isdiscapacities { get; set; }

        
        public bool IsSort { get; set; }
        public bool IsFilterByCreationDate { get; set; }
        public bool IsFilterByJobLevel { get; set; }
        public bool IsFilterByJobType { get; set; }
        public bool IsFilterByWorkType { get; set; }
        public bool IsFilterByCompany { get; set; }
        public bool IsFilterByArea { get; set; }
        public bool isFilterByDisability { get; set; }

        public string Sort { get; set; }
        public int CreationDate { get; set; }
        public int JobLevel { get; set; }
        public int JobType { get; set; }
        public int WorkType { get; set; }
        public int Company { get; set; }
        public int IdArea { get; set; }
        public int Idcategory { get; set; }
        public int CurrentPage { get; set; }

    }
}
