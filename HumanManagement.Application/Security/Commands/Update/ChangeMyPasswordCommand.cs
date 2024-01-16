using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Commands.Update
{
    public class ChangeMyPasswordCommand : IRequest<Result>
    {
        public ChangeMyPasswordDto ResetPassword { get; set; }
    }

    public class ChangeMyPasswordCommandHandler : IRequestHandler<ChangeMyPasswordCommand, Result>
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptography cryptography;
        private readonly IUserRepository userRepository;
        public ChangeMyPasswordCommandHandler(IBaseRepository<User> baseRepository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork,
                                            ICryptography cryptography,
                                            IUserRepository userRepository)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cryptography = cryptography;
            this.userRepository = userRepository;
        }

        public async Task<Result> Handle(ChangeMyPasswordCommand request, CancellationToken cancellationToken)
        {
            LoginDto Login = new LoginDto();

            var usermodel = await baseRepository.Find(request.ResetPassword.Id);

            Login.Password = request.ResetPassword.PasswordWithoutEncryptionOld;
            Login.Username = usermodel.UserName;

            Login.SetPassword(cryptography);


            var userLogged = await userRepository.Authenticate(Login);
            if (userLogged == null)
            {
                
                throw new ValidationException("Datos de usuario incorrecto");
            }

            Result result = new Result();


            ResetPasswordDto ressetPassword = new ResetPasswordDto();
            ressetPassword.PasswordWithoutEncryption=request.ResetPassword.PasswordWithoutEncryption;

            ressetPassword.SetPassword(cryptography);
            var user = mapper.Map<User>(ressetPassword);

            usermodel.Password = ressetPassword.Password;
            usermodel.DateUpdate = DateTime.Now;
            usermodel.ChangedPassword = true;


            await baseRepository.UpdatePartial(usermodel, x => x.Password,
                                                      x => x.DateUpdate,
                                                      x => x.ChangedPassword
                                                      );

            await unitOfWork.Commit();

            result.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            result.MessageError = new List<string>(){
                    "Se cambió la contraseña de manera correcta."
                };

            return result;
        }
    }
}
