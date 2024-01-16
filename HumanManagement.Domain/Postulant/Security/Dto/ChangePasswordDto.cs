using HumanManagement.Domain.Postulant.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Dto
{
    public class ChangePasswordDto
    {
        public int IdUser { get; set; }
        public string PasswordActual { get; set; }
        public string PasswordWithoutEncryption { get; set; }
        public string PasswordConfirm { get; set; }
        public string PasswordEncrypted { get; set; }

        public void SetPassword(ICryptography cryptography)
        {
            PasswordEncrypted = cryptography.GetMd5Hash(PasswordWithoutEncryption);
            PasswordActual = cryptography.GetMd5Hash(PasswordActual);
        }
    }
}
