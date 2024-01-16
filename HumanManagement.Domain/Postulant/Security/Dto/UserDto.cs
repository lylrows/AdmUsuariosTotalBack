using HumanManagement.Domain.Models;
using HumanManagement.Domain.Postulant.Security.Contracts;
using System;

namespace HumanManagement.Domain.Postulant.Security.Dto
{
    public class UserDto : Entity
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PasswordWithoutEncryption { get; set; }
        public int ResetPassword { get; set; }
        public byte[] PasswordResetCode { get; set; }
        public DateTime? PasswordResetStart { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public string ValidationInformative { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdTypeDocument { get; set; }
        public string DocumentNumber { get; set; }
        public string PhotoUrl { get; set; }
        public int IdProfile { get; set; }
        public bool ActiveAccount { get; set; }
        public void SetEncryptPassword(ICryptography cryptography)
        {
            Password = cryptography.GetMd5Hash(PasswordWithoutEncryption);
        }
    }
}
