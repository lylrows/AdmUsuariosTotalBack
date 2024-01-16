using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class SalaryPayrollDet : BaseModel.BaseModel
    {
        [Column("nid_payroll_det")]
        public int IdPayrollDet { get; set; }
        [Column("nidcompany")]
        public int IdCompany { get; set; }
        [Column("nconsecutive")]
        public int Consecutive { get; set; }
        [Column("scodemployee")]
        public string CodEmployee { get; set; }
        [Column("sconcept")]
        public string Concept { get; set; }
        [Column("spayroll")]
        public string Payroll { get; set; }
        [Column("npayrollnumber")]
        public Int16 PayRollNumber { get; set; }
        [Column("scostcenter")]
        public string CostCenter { get; set; }
        [Column("namount")]
        public decimal Amount { get; set; }
        [Column("ntotal")]
        public decimal Total { get; set; }
        [Column("sregistertype")]
        public string RegisterType { get; set; }
    }
}
