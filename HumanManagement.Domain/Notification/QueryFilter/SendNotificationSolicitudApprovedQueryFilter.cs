using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Notification.QueryFilter
{
   public class SolicitudApprovedQueryFilter
    {
        public int IdUser { get; set; }
        public int IdCompany { get; set; }
        public int IdProfile { get; set; }
        public int IsOption { get; set; }
        public int IdRequest { get; set; }
    }

}
