using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class TypeStaffRequestQueryFilter
    {
        public string Name { get; set; }
        public PaginationEntity Pagination { get; set; }
        public TypeStaffRequestQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
