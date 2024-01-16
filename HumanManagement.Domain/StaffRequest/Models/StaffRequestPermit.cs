using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestPermit
    {
        [Column("nid_staff_request")]
        public int IdStaffRequest { get; private set; }

        [Column("nid_permit_type")]
        public int IdPermitType { get; set; }

        [Column("ssupport")]
        public string Support { get; set; }

        [Column("dpermitdate")]
        public DateTime PermitDate { get; set; }

        [Column("dstarttime")]
        public DateTime StartTime { get; set; }

        [Column("dendtime")]
        public DateTime EndTime { get; set; }

        [Column("spathfiledocument")]
        public string PathFileDocument { get; set; }

        [Column("nnumberoutstandingbalance")]
        public int NumberOutstandingBalance { get; private set; }

        [Column("nnumbertruncatedbalance")]
        public int NumberTruncatedBalance { get; private set; }

        public void SetIdStaffRequest(int id)
        {
            IdStaffRequest = id;
        }
    }
}
