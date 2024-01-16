using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Domain.BaseModel;

namespace HumanManagement.Domain.Contact.Models
{
    public class Contact: BaseModel.BaseModel
    {
        
        [Column("nid_contact")]
        public int Id { get; set; }
        [Column("sname")]
        public string Name { get; set; }
        [Column("sposition")]
        public string Position { get; set; }
        [Column("sphone")]
        public string Phone { get; set; }
        [Column("sreason")]
        public string Reason { get; set; }
        [Column("sphoto_url")]
        public string Photo_url { get; set; }
        [Column("nid_employee")]
        public int? Id_Employee{ get; set; }

        [Column("sextension")]
        public string Extension { get; set; }

        [Column("semail")]
        public string Email { get; set; }
        


    }
}
