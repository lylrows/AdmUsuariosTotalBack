using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Models;
using System;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Services
{
    public class LoginAttemptService : ILoginAttemptService
    {
        private readonly IUserRepository userRepository;
        private readonly IBaseRepository<LoginAttempt> baseLoginAttemptRepository;
        private readonly IBaseRepository<User> baseUserRepository;
        private readonly ILoginAttemptRepository loginAttemptRepository;
        private readonly IUnitOfWork unitWork;
        private const int NUMBER_ATTEMPT = 3;
        public LoginAttemptService(IUserRepository userRepository, 
                                   IBaseRepository<LoginAttempt> baseLoginAttemptRepository,
                                   IBaseRepository<User> baseUserRepository,
                                   ILoginAttemptRepository loginAttemptRepository,
                                   IUnitOfWork unitWork)
        {
            this.userRepository = userRepository;
            this.baseLoginAttemptRepository = baseLoginAttemptRepository;
            this.loginAttemptRepository = loginAttemptRepository;
            this.baseUserRepository = baseUserRepository;
            this.unitWork = unitWork;
        }

        public async Task AddAttempt(string userName)
        {
            int idUser = userRepository.GetIdByUserName(userName).Result;
            if (idUser > 0)
            {
                int idLoginAttempt = await loginAttemptRepository.GetByIdUser(idUser);
                if (idLoginAttempt == 0)
                {
                    LoginAttempt loginAttempt = new LoginAttempt
                    {
                        Id = idLoginAttempt,
                        IdUser = idUser,
                        NumberAttempts = 1,
                        Active = true
                    };
                    await baseLoginAttemptRepository.Add(loginAttempt);
                }
                else
                {
                    await loginAttemptRepository.UpdateAttempt(idLoginAttempt);
                    int numberAttempts = await loginAttemptRepository.GetNumberAttempts(idLoginAttempt);
                    if (numberAttempts >= NUMBER_ATTEMPT)
                    {
                        User user = new User
                        {
                            Id = idUser,
                            Blocked = true
                        };
                        await baseUserRepository.UpdatePartial(user, x => x.Blocked,
                                                   x => x.DateUpdate,
                                                   x => x.IdUserUpdate);
                    }
                }
                await unitWork.Commit();
            }
        }
    }
}
