using HumanManagement.Domain.StaffRequest.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestModel : BaseModel.BaseModel
    {
        [Column("nid_staff_request")]
        public int Id { get; set; }

        [Column("nid_type_staff_request")]
        public int IdTypeStaffRequest { get; set; }

        [Column("nid_employee")] 
        public int IdEmployee { get; set; }

        [Column("ddateissue")]
        public DateTime DateIssue { get; set; }

        [Column("sregistrynumber")]
        public string RegistryNumber { get; set; }

        [Column("nid_charge")] 
        public int IdCharge { get; set; }

        [Column("ddateadmission")]
        public DateTime DateAdmission { get; set; }

        [Column("nstate")]
        public int State { get; private set; }
        public void SetStatePending()
        {
            State = Convert.ToInt16(StaffRequestState.PENDING);
        }
        public void SetState(int state)
        {
            State = state;
        }
        public void SetStateRejected()
        {
            State = Convert.ToInt16(StaffRequestState.REJECTED);
        }
        public void SetComment(string scomment)
        {
            Comment = scomment;
        }
        [Column("smonth_pay")]
        public string monthPay { get; set; }
        [Column("syear_pay")]
        public string yearPay { get; set; }
        [Column("scomment")]
        public string Comment { get; set; }
        [Column("nterms")]
        public int TerminosYCond { get; set; }
    }
}
