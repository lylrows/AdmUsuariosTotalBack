namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestApproverDto
    {
        public int IdStaffRequest { get; set; }
        public int IdTypeStaffRequest { get; set; }
        public int IdCharge { get; set; }
        public int IdProfile { get; set; }
        public bool AllowApproveAll { get; set; }
        public int Level { get; set; }
        public int State { get; set; }
        public string Comment { get; set; }
    }
}
