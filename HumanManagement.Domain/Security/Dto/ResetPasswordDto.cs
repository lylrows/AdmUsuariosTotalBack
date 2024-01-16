using HumanManagement.Domain.Security.Contracts;

namespace HumanManagement.Domain.Security.Dto
{
    public class ResetPasswordDto
    {
        public int Id { get; set; }
        public string Password { get; private set; }
        public string PasswordWithoutEncryption { get; set; }

        public string PasswordConfirm { get; set; }
        public string CodeBase64Url { get; set; }

        public void SetPassword(ICryptography cryptography)
        {
            Password = cryptography.GetMd5Hash(PasswordWithoutEncryption);
        }
    }
}
