using System;

namespace HumanManagement.Domain.Notification.Dto
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int? IdArea { get; set; }
        public int IdCompany { get; set; }
        public int IdPerson { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public bool Active { get; set; }
        public int IdReceptor { get; set; }
        public bool IsApprovedRRHH { get; set; }
        public int IdUser { get; set; }
        public int IsOption { get; set; }
    }
  
    public class SendNotificationSolicitudApprovedDto
    {
        public int nid_area { get; set; }
        public int nid_person { get; set; }
        public int nid_receptor { get; set; }
        public string email_receptor { get; set; }
    }

    public class SendNotificationNotSeltectedDto
    {
        public int IdEvaluation { get; set; }
        public string Type { get; set; }
    }

}
