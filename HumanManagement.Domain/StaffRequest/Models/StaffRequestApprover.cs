using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestApprover : BaseModel.BaseModel
    {
        [Column("nid_approver")]
        public int Id { get; set; }

        [Column("nid_staff_request")]
        public int IdStaffRequest { get; set; }

        [Column("nid_charge")]
        public int IdCharge { get; set; }

        [Column("nid_employee")]
        public int IdEmployee { get; set; }

        [Column("nlevel")]
        public int Level { get; set; }

        [Column("nstate")]
        public int State { get; private set; }

        [Column("nid_profile")]
        public int IdProfile { get; set; }

        [Column("scomment")]
        public string Comment { get; set; }

        public void SetState(int state)
        {
            State = state;
        }
    }
}
