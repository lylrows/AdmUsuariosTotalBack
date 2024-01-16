using FluentValidation;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.Entities;
using HumanManagement.Domain.Security.Models;

using MediatR;
using Microsoft.Extensions.Options;
using System;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{
    public class GetLoginUserQuery: IRequest<Result>
    {
        public LoginDto Login { get; set; }
        public class GetLoginUserQueryHandler : IRequestHandler<GetLoginUserQuery, Result>
        {
            private readonly IUserRepository userRepository;
            private readonly IProfileUserRepository profileUserRepository;
            private readonly IProfileResourceRepository profileResourceRepository;
            private readonly ICryptography cryptography;
            private readonly ILoginAttemptService loginAttemptService;
            private readonly ITokenUserService tokenUserService;
            private readonly AppSettings appSettings;
            private readonly ITokenGenerator tokenGenerator;
            public GetLoginUserQueryHandler(IUserRepository userRepository, 
                                            ICryptography cryptography, 
                                            IProfileUserRepository profileUserRepository,
                                            IProfileResourceRepository profileResourceRepository,
                                            ILoginAttemptService loginAttemptService,
                                            ITokenUserService tokenUserService,
                                            IOptions<AppSettings> appSettings,
                                            ITokenGenerator tokenGenerator)
            {
                this.userRepository = userRepository;
                this.cryptography = cryptography;
                this.profileUserRepository = profileUserRepository;
                this.profileResourceRepository = profileResourceRepository;
                this.loginAttemptService = loginAttemptService;
                this.appSettings = appSettings.Value;
                this.tokenGenerator = tokenGenerator;
                this.tokenUserService = tokenUserService;
        }
            public async Task<Result> Handle(GetLoginUserQuery query, CancellationToken cancellationToken)
            {
                query.Login.SetPassword(cryptography);
                var userLogged = await userRepository.Authenticate(query.Login);
                if (userLogged == null)
                {
                    await loginAttemptService.AddAttempt(query.Login.Username);
                    
                    throw new ValidationException("Usuario y/o Contraseña incorrrecto.");
                }
                if (userLogged.Blocked)
                {
                    
                    throw new ValidationException("Usuario Bloqueado.<br/>Contacte con el equipo de soporte de RRHH: grupofeconfigo@grupofe.com.pe");
                }
                int idprofile = await profileUserRepository.GetProfileByUser(userLogged.Id);
                var resource = await profileResourceRepository.GetListResource(idprofile);
                
                userLogged.SetPhotoUserDefault("../../../../../assets/images/avatars/avatar.jpg");
                userLogged.SetPhotoCompanyDefault(appSettings.URL_PHOTO_COMPANY_DEFAULT);
                ProfileGenerator profileGenerator = new ProfileGenerator(userLogged, resource);

                var profileUser = profileGenerator.GetUserProfile(tokenGenerator);
                TokenUser tokenUser = new TokenUser
                {
                    IdUser = userLogged.Id,
                    Token = profileUser.Token,
                    TokenLife = profileUser.TokenLife,
                    Active = true,
                    DateRegister = DateTime.Now,
                    DateUpdate = DateTime.Now
                };
                await tokenUserService.AddOrUpdate(tokenUser);
                return new Result
                {
                    StateCode = 200,
                    Data = profileUser
                };
            }
        }
    }
}
