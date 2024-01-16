using HumanManagement.Domain.Postulant.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Dto
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordEncrypted { get; private set; }

        public void SetPassword(ICryptography cryptography)
        {
            PasswordEncrypted = cryptography.GetMd5Hash(Password);
        }
    }
}
