using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Entities
{
    public class Password
    {
        string value;
        public Password(string value)
        {
            this.value = value;
        }

        public string GenerateKey()
        {
            return "";
        }
    }
}
