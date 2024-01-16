using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Services
{
    public class TokenUserService : ITokenUserService
    {
        private readonly IBaseRepository<TokenUser> baseTokenUserRepository;
        private readonly ITokenUserRepository tokenUserRepository;

        public TokenUserService(IBaseRepository<TokenUser> baseTokenUserRepository,
                                ITokenUserRepository tokenUserRepository)
        {
            this.baseTokenUserRepository = baseTokenUserRepository;
            this.tokenUserRepository = tokenUserRepository;
        }
        public async Task AddOrUpdate(TokenUser tokenUser)
        {
            int idToken = await tokenUserRepository.GetIdTokenActiveByUser(tokenUser.IdUser);
            if (idToken > 0)
            {
                TokenUser tokenUserUpdate = new TokenUser
                {
                    Id = idToken,
                    Active = false,
                    DateUpdate = DateTime.Now
                };
                await baseTokenUserRepository.UpdatePartial(tokenUserUpdate, x => x.Active,
                                                                    x => x.DateUpdate);
            }
            await baseTokenUserRepository.Add(tokenUser);
        }
    }
}
