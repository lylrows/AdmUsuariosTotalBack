using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Security.Services
{
    public class TokenUserService : ITokenUserService
    {
        private readonly IBaseRepository<TokenUserPostulant> baseTokenUserRepository;
        private readonly ITokenUserRepository tokenUserRepository;

        public TokenUserService(IBaseRepository<TokenUserPostulant> baseTokenUserRepository,
                                ITokenUserRepository tokenUserRepository)
        {
            this.baseTokenUserRepository = baseTokenUserRepository;
            this.tokenUserRepository = tokenUserRepository;
        }
        public async Task AddOrUpdate(TokenUserPostulant tokenUser)
        {
            int idToken = await tokenUserRepository.GetIdTokenActiveByUser(tokenUser.IdUser);
            if (idToken > 0)
            {
                TokenUserPostulant tokenUserUpdate = new TokenUserPostulant
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
