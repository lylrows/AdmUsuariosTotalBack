using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Notification.Dto
{
    public class BandejaNotificacionDto
    {
        public int Id { get; set; }
        public int IdArea { get; set; }
        public int IdPerson { get; set; }
        public string Sender { get; set; }
        public string SenderPhoto { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Selected { get; set; }
        public DateTime SendDate { get; set; }
        public bool Active { get; set; }
        public bool Important { get; set; }
        public bool Favorite { get; set; }
        public int? IdPersonReceptor { get; set; }
        public int? IdUserReceptor { get; set; }
        public string RelativeSendDate { get; set; }
        public bool Viewed { get; set; }
    }
}
