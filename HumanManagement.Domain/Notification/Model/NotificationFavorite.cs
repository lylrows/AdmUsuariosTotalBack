using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Notification.Model
{
    public class NotificationFavorite : BaseModel.BaseModel
    {
        [Column("nid_notification")]
        public int Id { get; set; }

        [Column("nid_receptor")]
        public int IdReceptor { get; set; }

    }
}
