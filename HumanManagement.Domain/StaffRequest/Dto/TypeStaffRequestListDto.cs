using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class TypeStaffRequestListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public List<TypeStaffRequestApproverDto> TypeStaffRequestApproverList { get; set; }
    }
}
