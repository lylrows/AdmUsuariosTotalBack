namespace HumanManagement.Domain.Security.Dto
{
    public class UserSessionDto
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public int IdEmployee { get; set; }
        public string Email { get; set; }
        public int IdProfile { get; set; }
    }
}
