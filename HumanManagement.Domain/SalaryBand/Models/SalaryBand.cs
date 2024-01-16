using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class SalaryBand : BaseModel.BaseModel
    {
        [Column("nid_bandbox")]
        public int IdBandBox { get; set; }
        [Column("nid_group")]
        public int IdGroup { get; set; }

        [Column("snamegroup")]
        public string NameGroup { get; set; }
        [Column("sname_category")]
        public string NameCategory { get; set; }


        [Column("spoints")]
        public string Points { get; set; }
        [Column("nminimum_point")]
        public decimal MininumPoint { get; set; }
        [Column("nmiddle_point")]
        public decimal MiddlePoint { get; set; }
        [Column("nmaximun_point")]
        public decimal MaximunPoint { get; set; }
        [Column("nbandwidth")]
        public decimal BandhWidth { get; set; }

    }
}
