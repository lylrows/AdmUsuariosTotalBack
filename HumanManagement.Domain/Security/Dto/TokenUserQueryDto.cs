using System;

namespace HumanManagement.Domain.Security.Dto
{
    public class TokenUserQueryDto
    {
        public string Token { get; set; }
        public string ApiRoute { get; set; }
    }
}
