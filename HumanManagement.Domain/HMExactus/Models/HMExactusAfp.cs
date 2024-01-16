using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.HMExactus.Models
{
    public class HMExactusAfp : BaseModel.BaseModel
    {
        [Column("scode")]
        public string Code { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }
        [Column("svalue1")]
        public string Value1 { get; set; }
        [Column("svalue2")]
        public string Value2 { get; set; }
        [Column("svalue3")]
        public string Value3 { get; set; }
        [Column("svalue4")]
        public string Value4 { get; set; }
    }
}
