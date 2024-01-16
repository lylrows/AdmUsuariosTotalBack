using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestJustificationTardiness
    {
        [Column("nid_staff_request")]
        public int IdStaffRequest { get; private set; }

        [Column("ssupport")]
        public string Support { get; set; }

        [Column("dtardinessdate")]
        public DateTime tardinessDate { get; set; }

        [Column("dstarttime")]
        public DateTime StartTime { get; set; }

        [Column("dendtime")]
        public DateTime EndTime { get; set; }

        [Column("spathfiledocument")]
        public string PathFileDocument { get; set; }
        public void SetIdStaffRequest(int id)
        {
            IdStaffRequest = id;
        }
    }
}
