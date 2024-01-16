using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class AreaGroup : BaseModel.BaseModel
    {
        [Column("nid_areagroup")]
        public int IdAreaGroup { get; set; }
        [Column("snamegroup")]
        public string NameGroup { get; set; }

        [Column("norder")]
        public int Order { get; set; }

    }
}
