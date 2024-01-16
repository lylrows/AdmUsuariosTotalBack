using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Notification.Model
{
    public class NotificationModel : BaseModel.BaseModel
    {
        [Column("nid_notification")]
        public int Id { get; set; }

        [Column("nid_area")]
        public int? IdArea { get; set; }

        [Column("nid_person")]
        public int IdPerson { get; set; }

        [Column("ssubject")]
        public string Subject { get; set; }

        [Column("sbody")]
        public string Body { get; set; }

        [Column("dsenddate")]
        public DateTime SendDate { get; set; }

        [Column("bimportant")]
        public bool Important { get; set; }

        [Column("bfavorite")]
        public bool Favorite { get; set; }
        [Column("nid_receptor")]
        public int IdReceptor { get; set; }
        [Column("bisapprovedrrhh")]
        public bool IsApprovedRRHH { get; set; }
    }
}
