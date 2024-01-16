using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class ListRequestFlowDto
    {
        public int Id { get; set; }
        public int IdOriginArea { get; set; }
        public int IdDestinationArea { get; set; }
        public string OriginArea { get; set; }
        public string DestinationArea { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string TimeAll { get; set; }
        public string Comment { get; set; }
        public string State { get; set; }
    }
}
