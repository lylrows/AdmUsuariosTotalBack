namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class TypeStaffRequestApproverDto
    {
        public int IdTypeStaffRequest { get; set; }
        public int IdApprover { get; set; }
        public int IdCharge { get; set; }
        public int IdProfile { get; set; }
        public int Level { get; set; }
        public string Charge { get; set; }
        public string Profile { get; set; }
        public string Name { get; set; }
        public int IdArea { get; set; }
        public bool AllowApproveAll { get; set; }
    }
}
