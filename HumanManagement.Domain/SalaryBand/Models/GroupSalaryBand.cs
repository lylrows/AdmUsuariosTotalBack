using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class GroupSalaryBand :  BaseModel.BaseModel
    {
        [Column("nid_group")]
        public int IdGroup { get; set; }
        [Column("snamegroup")]
        public string NameGroup { get; set; }
        [Column("sname_category")]
        public string NameCategory { get; set; }
    }
}
