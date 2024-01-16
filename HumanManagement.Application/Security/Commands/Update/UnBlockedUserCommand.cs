using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Commands.Update
{
    public class UnBlockedUserCommand : IRequest<Result>
    {
        public int Id { get; set; }

    }

    public class UnBlockedUserCommandHandler : IRequestHandler<UnBlockedUserCommand, Result>
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly ILoginAttemptRepository loginAttemptRepository;
        private readonly IBaseRepository<LoginAttempt> baseLoginAttemptRepository;

        public UnBlockedUserCommandHandler(IBaseRepository<User> baseRepository, 
                IBaseRepository<LoginAttempt> baseLoginAttemptRepository,
                ILoginAttemptRepository loginAttemptRepository)
        {
            this.baseRepository = baseRepository;
            this.loginAttemptRepository = loginAttemptRepository;
            this.baseLoginAttemptRepository = baseLoginAttemptRepository;
        }

        public async Task<Result> Handle(UnBlockedUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                Id = request.Id,
                Blocked = false
            }; 
            await baseRepository.UpdatePartial(user, x => x.Blocked,
                                               x => x.DateUpdate,
                                               x => x.IdUserUpdate);

            int idLoginAttempt = await loginAttemptRepository.GetByIdUser(request.Id);
            if (idLoginAttempt != 0)
            {
                LoginAttempt loginAttempt = new LoginAttempt
                {
                    Id = idLoginAttempt,
                    IdUser = request.Id,
                    NumberAttempts = 0,
                    Active = true
                };

                await baseLoginAttemptRepository.UpdatePartial(loginAttempt, x => x.NumberAttempts);
            }
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }

}
