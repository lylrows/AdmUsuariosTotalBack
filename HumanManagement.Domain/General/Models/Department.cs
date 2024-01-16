using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.General.Models
{
    public class Department :BaseModel.BaseModel
    {
        [Column("nid_department")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }
    }
}
