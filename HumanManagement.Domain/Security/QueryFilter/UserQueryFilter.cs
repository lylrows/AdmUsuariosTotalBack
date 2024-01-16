using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Security.QueryFilter
{
    public class UserQueryFilter
    {
        public int IdCompany { get; set; }
        public int IdArea { get; set; }
        public string chargeName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Active { get; set; }
        public int nsituation { get; set; }
        public PaginationEntity pagination { get; set; }
        public UserQueryFilter()
        {
            pagination = new PaginationEntity();
        }

    }
}
