using System;

namespace HumanManagement.Domain.Notification.Dto
{
    public class NotificationListDto
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string NameArea { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Active { get; set; }
        public DateTime SendDate { get; set; }
        public int IdCompany { get; set; }
        public int IdArea { get; set; }
    }
}
