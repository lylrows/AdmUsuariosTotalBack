using System;

namespace HumanManagement.Domain.Postulant.Security.Dto
{
    public class TokenUserDto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Token { get; set; }
        public int TokenLife { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
