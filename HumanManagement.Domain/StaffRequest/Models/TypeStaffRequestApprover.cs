using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class TypeStaffRequestApprover
    {
        [Column("nid_type_staff_request")]
        public int IdTypeStaffRequest { get; set; }

        [Column("nid_approver")]
        public int IdApprover { get; set; }

        [Column("nid_charge")]
        public int IdCharge { get; set; }

        [Column("nlevel")]
        public int Level { get; set; }

        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("ballowapproveall")]
        public bool AllowApproveAll { get; set; }
    }
}
