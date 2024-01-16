using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Models
{
    public class SalaryPayrollCab : BaseModel.BaseModel
    {
        [Column("nid_payroll_cab")]
        public int IdPayrollCab { get; set; }
        [Column("nidcompany")]
        public int IdCompany { get; set; }
        [Column("snominacode")]
        public string NominaCode { get; set; }
        [Column("snominanumber")]
        public int NominaNumber { get; set; }
        [Column("nyear")]
        public int Year { get; set; }
        [Column("nmonth")]
        public int Month { get; set; }
        [Column("PERIODO")]
        public DateTime? PERIODO { get; set; }
        [Column("FECHA_APROBACION")]
        public DateTime? FECHA_APROBACION { get; set; }
        [Column("FECHA_PAGO")]
        public DateTime? FECHA_PAGO { get; set; }
        [Column("APROBADA_POR")]
        public string APROBADA_POR { get; set; }
    }
}
