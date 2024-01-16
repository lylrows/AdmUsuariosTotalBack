using HumanManagement.Domain.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Dto
{
    public class ChangeMyPasswordDto
    {
        public int Id { get; set; }
        public string Password { get; private set; }
        public string PasswordWithoutEncryption { get; set; }

        public string PasswordWithoutEncryptionOld { get; set; }
        public string PasswordOld { get; set; }

        public string PasswordConfirm { get; set; }
        

        public void SetPassword(ICryptography cryptography)
        {
            Password = cryptography.GetMd5Hash(PasswordWithoutEncryption);
        }
    }
}
