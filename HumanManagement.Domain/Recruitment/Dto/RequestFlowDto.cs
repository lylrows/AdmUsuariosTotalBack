using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class RequestFlowDto
    {
        public int Id { get; set; }
        public int IdOriginArea { get; set; }
        public int IdDestinationArea { get; set; }
        public int State { get; set; }
        public string Comment { get; set; }
        public int UserRegister { get; set; }
    }
}
