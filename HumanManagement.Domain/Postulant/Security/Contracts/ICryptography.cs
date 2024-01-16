using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Security.Contracts
{
    public interface ICryptography
    {
        string GetMd5Hash(string input);

        bool VerifyMd5Hash(string input, string hash);
    }
}
