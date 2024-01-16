using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.RecruitmentArea.Models
{
    public class RecruitmentArea : BaseModel.BaseModel
    {
        [Column("nid_area")]
        public int Id_Area { get; set; }
        [Column("sareaname")]
        public string AreaName { get; set; }

    }
}
