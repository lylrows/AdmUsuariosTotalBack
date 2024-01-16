using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HumanManagement.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly TokenOption tokenOption;
        private readonly JwtOptions jwtOptions;
        public int TokenLife { get; private set; }
        public TokenGenerator(IOptions<TokenOption> tokenOption, IOptions<JwtOptions> jwtOptions)
        {
            this.tokenOption = tokenOption.Value;
            this.jwtOptions = jwtOptions.Value;
            TokenLife = this.jwtOptions.ExpiryMinutes;
        }
        public string Generate(int IdUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenOption.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, IdUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(jwtOptions.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int GetTokenLife()
        {
            return TokenLife;
        }
    }
}
