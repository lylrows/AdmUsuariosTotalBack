using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class TypeStaffRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public List<TypeStaffRequestApproverDto> TypeStaffRequestApproverList { get; set; }
        public TypeStaffRequestDto()
        {
            TypeStaffRequestApproverList = new List<TypeStaffRequestApproverDto>();
        }
    }
}
