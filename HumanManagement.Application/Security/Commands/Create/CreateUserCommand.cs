using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.Events;
using HumanManagement.Domain.Security.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Commands.Create
{
    public class CreateUserCommand : IRequest<Result>
    {
        public UserDto User { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IBaseRepository<User> baseUserRepository;
        private readonly IBaseRepository<ProfileUser> baseProfileUserRepository;
        private readonly IBaseRepository<PersonModel> personRepository;
        private readonly IBaseRepository<Phone> phoneRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptography cryptography;
        public CreateUserCommandHandler(IBaseRepository<User> baseUserRepository,
                                        IBaseRepository<PersonModel> personRepository,
                                        IBaseRepository<Phone> phoneRepository,
                                        IBaseRepository<ProfileUser> baseProfileUserRepository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        ICryptography cryptography)
        {
            this.baseUserRepository = baseUserRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cryptography = cryptography;
            this.personRepository = personRepository;
            this.phoneRepository = phoneRepository;
            this.baseProfileUserRepository = baseProfileUserRepository;
        }
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.SetEncryptPassword(cryptography);
            var user = mapper.Map<User>(request.User);
            var person = mapper.Map<PersonModel>(request.User);
            person.DateRegister = DateTime.Now;
            person.DateUpdate = DateTime.Now;
            person.Identification = "1111";
            person.IdSex = 12;
            person.IdActive = 24;
            await personRepository.Add(person);
            var phone = mapper.Map<Phone>(request.User);
            if (phone != null)
            {
                phone.IdPerson = person.Id;
                phone.DateRegister = DateTime.Now;
                phone.DateUpdate = DateTime.Now;
                await phoneRepository.Add(phone);
            }
            user.IdPerson = person.Id;
            await baseUserRepository.Add(user);
            var profileUser = mapper.Map<ProfileUser>(request.User);
            profileUser.IdUser = user.Id;
            await baseProfileUserRepository.Add(profileUser);
            await unitOfWork.Commit();

            UserMailDto userMailDto = new UserMailDto
            {
                UserName = user.UserName,
                Password = request.User.PasswordWithoutEncryption,
                FullName = $"{person.FirstName} {person.SecondName} {person.LastName} {person.MotherLastName}",
                Email = person.Email
            };
            var userRegistered = new UserRegistered(userMailDto);

            DomainEvent.Raise(userRegistered);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
