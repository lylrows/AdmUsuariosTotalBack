namespace HumanManagement.Domain.Security.Dto
{
    public class UserGridView
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DocumentNumber { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public string NameArea { get; set; }
        public string NameCompany { get; set; }
        public string NameCharge { get; set; }
        public int IdProfile { get; set; }
        public string Profile { get; set; }
        public string Photo { get; set; }
    }
}
