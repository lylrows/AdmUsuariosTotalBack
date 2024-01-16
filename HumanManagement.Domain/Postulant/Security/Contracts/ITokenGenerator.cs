namespace HumanManagement.Domain.Postulant.Security.Contracts
{
    public interface ITokenGenerator
    {
        string Generate(int IdUser);
        int GetTokenLife();
    }
}
