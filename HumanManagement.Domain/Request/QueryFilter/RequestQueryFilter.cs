using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Request.QueryFilter
{
    public class RequestQueryFilter
    {
        public PaginationEntity Pagination { get; set; }
        public RequestQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
