using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestAdvancementDto
    {
        public int IdStaffRequest { get; set; }
        public int nid_collaborator { get; set;}
        public int nid_person { get; set; }
        public decimal namount { get; set; }
        public int nreason { get; set;}
        public string sdetailreason { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }

        public StaffRequestDto StaffRequest { get; set; }
        public StaffRequestAdvancementDto()
        {
            StaffRequest = new StaffRequestDto();
        }
    }
}
