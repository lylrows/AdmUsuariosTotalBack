using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Models
{
    public class ProfilePostulant
    {
        [Column("nid_profile")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }
    }
}
