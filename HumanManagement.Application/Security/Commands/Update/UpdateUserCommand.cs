using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Commands.Update
{
    public class UpdateUserCommand : IRequest<Result>
    {
        public UserDto User { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IBaseRepository<User> baseUserRepository;
        private readonly IBaseRepository<ProfileUser> baseProfileUserRepository;
        private readonly IBaseRepository<PersonModel> personRepository;
        private readonly IBaseRepository<Phone> phoneBaseRepository;
        private readonly IPhoneRepository phoneRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProfileUserRepository profileUserRepository;
        public UpdateUserCommandHandler(IBaseRepository<User> baseUserRepository,
                                        IBaseRepository<PersonModel> personRepository,
                                        IBaseRepository<Phone> phoneBaseRepository,
                                        IBaseRepository<ProfileUser> baseProfileUserRepository,
                                        IPhoneRepository phoneRepository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IProfileUserRepository profileUserRepository)
        {
            this.baseUserRepository = baseUserRepository;
            this.personRepository = personRepository;
            this.phoneBaseRepository = phoneBaseRepository;
            this.phoneRepository = phoneRepository;
            this.baseProfileUserRepository = baseProfileUserRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.profileUserRepository = profileUserRepository;

        }
        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request.User);
            user.DateRegister = DateTime.Now;
            user.DateUpdate = DateTime.Now;
            var person = mapper.Map<PersonModel>(request.User);
            person.Id = user.IdPerson;
            var profileUser = mapper.Map<ProfileUser>(request.User);
            profileUser.IdUser = user.Id;
            var result = profileUserRepository.UpdateProfile(profileUser.IdProfile, profileUser.IdUser);
            var phone = mapper.Map<Phone>(request.User);
            phone.Id = 0;
            phone.IdPerson = user.IdPerson;
            phone.DateRegister = DateTime.Now;
            phone.UserRegister = 1;
            phone.DateUpdate = DateTime.Now;
            phone.UserUpdate = 1;
            if (string.IsNullOrEmpty(user.PhotoUrl))
            {
                await baseUserRepository.UpdatePartialNotIncluding(user, x => x.Password,
                                                                x => x.DateRegister,
                                                                x => x.IdUserRegister,
                                                                x => x.ChangedPassword,
                                                                x=>x.PhotoUrl);
            }
            else
            {
                await baseUserRepository.UpdatePartialNotIncluding(user, x => x.Password,
                                                                x => x.DateRegister,
                                                                x => x.IdUserRegister,
                                                                x => x.ChangedPassword);
            }
            
            await personRepository.UpdatePartial(person, x => x.FirstName,
                                                         x => x.SecondName,
                                                         x => x.LastName,
                                                         x => x.MotherLastName,
                                                         x => x.Email,
                                                         x => x.DateUpdate,
                                                         x => x.IdUserUpdate);
            await phoneRepository.DeleteByPerson(person.Id);
            await phoneBaseRepository.Add(phone);
            

            await unitOfWork.Commit();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
