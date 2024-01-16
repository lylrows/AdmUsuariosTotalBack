using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface IPasswordGenerator
    {
        string Generate(int length);
    }
}
