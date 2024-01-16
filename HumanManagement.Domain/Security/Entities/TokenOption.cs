
namespace HumanManagement.Domain.Security.Entities
{
    public class TokenOption
    {
        public string Secret { get; set; }
        public string SecretPublic { get; set; }
        public string ExpireToken { get; set; }
    }
}
