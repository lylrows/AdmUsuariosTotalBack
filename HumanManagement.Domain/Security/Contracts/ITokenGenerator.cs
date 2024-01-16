﻿namespace HumanManagement.Domain.Security.Contracts
{
    public interface ITokenGenerator
    {
        string Generate(int IdUser);
        int GetTokenLife();
    }
}
