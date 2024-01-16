using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestVacation
    {
        [Column("nid_staff_request")]
        public int IdStaffRequest { get; private set; }

        [Column("dstartvacation")]
        public DateTime StartVacation { get; set; }

        [Column("dendvacation")]
        public DateTime EndVacation { get; set; }

        [Column("nnumbercalendardays")]
        public int NumberCalendarDays { get; private set; }

        [Column("nnumberbusinessdays")]
        public int NumberBusinessDays { get; private set; }

        [Column("svacationperiod")]
        public string VacationPeriod { get; private set; }

        [Column("nnumberoutstandingbalance")]
        public int NumberOutstandingBalance { get; private set; }

        [Column("nnumbertruncatedbalance")]
        public int NumberTruncatedBalance { get; private set; }

        public void SetVacationPeriod()
        {
            VacationPeriod = $"{StartVacation.ToShortDateString()} al {EndVacation.ToShortDateString()}";
        }
        public void SetIdStaffRequest(int id)
        {
            IdStaffRequest = id;
        }
    }
}
