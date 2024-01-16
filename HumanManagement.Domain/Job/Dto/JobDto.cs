using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobDto
    {

        public int id_job { get; set; }
        public string stitle { get; set; }
        public string snoticedetails { get; set; }
        public string srequirements { get; set; }
        public string sbenefits { get; set; }
        public decimal? nsalary { get; set; }
        public string slocation { get; set; }
        public string smodality { get; set; }
        public string stags { get; set; }
        public string sarea { get; set; }
        public string srelativetime { get; set; }
        public DateTime dcreationdate { get; set; }
        public string screationdate { get; set; }
        public string sjobtype { get; set; }
        public string scompanyimageurl { get; set; }
        public string scompanyname { get; set; }
        public int idcompany { get; set; }
        public bool isSuitableForDisabled { get; set; }


    }
}
