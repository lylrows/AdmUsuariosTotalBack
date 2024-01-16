using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.HMExactus.Models
{
    public class HMExactusFinancialEntity : BaseModel.BaseModel
    {
        [Column("scode")]
        public string Code { get; set; }
        [Column("snit")]
        public string Nit { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }
    }
}
