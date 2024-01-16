namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class NotificationReceptorDto
    {
        public int IdReceptor { get; set; }
        public string EvaluatorFullName { get; set; }
        public int IdArea { get; set; }
        public string TypeStaffRequest { get; set; }
        public string EmplyeeFullName { get; set; }
        public string EmplyeeDni { get; set; }
        public string RolName { get; set; }
        public int IdStaffRequest { get; set; }
    }
}
