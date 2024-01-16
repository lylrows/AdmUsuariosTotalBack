using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class Budget : BaseModel.BaseModel
    {
        [Column("nid_budget")]
        public int IdBudget { get; set; }
        [Column("nperiod")]
        public int Period { get; set; }
        [Column("nid_area")]
        public int IdArea { get; set; }
        [Column("nid_employee")]
        public int IdEmployee { get; set; }
        [Column("namount")]
        public decimal Amount { get; set; }        
    }
}
