using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Notification.QueryFilter
{
    public class NotificationQueryFilter
    {
        public int IdCompany { get; set; }
        public int IdArea { get; set; }
        public string Subject { get; set; }
        public PaginationEntity pagination { get; set; }
        public NotificationQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }


}
