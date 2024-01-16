using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.HMExactus.Models
{
    public class HMExactusPayroll : BaseModel.BaseModel
    {
        [Column("scodepayroll")]
        public string Code { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }
        [Column("ndays_habs_vaca")]
        public int DaysHabsVaca { get; set; }
    }
}
