using HumanManagement.Domain.Postulant.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Dto
{
    public class DeleteUserDto
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public string Motivo { get; set; }
        public string PasswordActual { get; set; }

        public void SetPassword(ICryptography cryptography)
        {
            PasswordActual = cryptography.GetMd5Hash(PasswordActual);
        }
    }
}
