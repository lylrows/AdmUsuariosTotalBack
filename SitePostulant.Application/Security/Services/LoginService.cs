using FluentValidation;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Dto;
using HumanManagement.Domain.Postulant.Security.Entities;
using HumanManagement.Domain.Postulant.Security.Models;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Response;
using SitePostulant.Application.Security.IServices;
using System;

using System.IO;

using System.Threading.Tasks;

namespace SitePostulant.Application.Security.Services
{
    public class LoginService : ILoginService
    {
        private readonly HumanManagement.Domain.Postulant.Security.Contracts.IUserRepository userRepository;
        private readonly HumanManagement.Domain.Postulant.Security.Contracts.IProfileUserRepository profileUserRepository;
        
        private readonly ICryptography cryptography;
        private readonly HumanManagement.Domain.Postulant.Security.Contracts.ITokenUserService tokenUserService;
        private readonly AppSettings appSettings;
        private readonly ITokenGenerator tokenGenerator;

        public LoginService(HumanManagement.Domain.Postulant.Security.Contracts.IUserRepository userRepository,
                                            ICryptography cryptography,
                                            HumanManagement.Domain.Postulant.Security.Contracts.IProfileUserRepository profileUserRepository,
                                            
                                            HumanManagement.Domain.Postulant.Security.Contracts.ITokenUserService tokenUserService,
                                            IOptions<AppSettings> appSettings,
                                            ITokenGenerator tokenGenerator)
        {
            this.userRepository = userRepository;
            this.cryptography = cryptography;
            this.profileUserRepository = profileUserRepository;
            
            this.appSettings = appSettings.Value;
            this.tokenGenerator = tokenGenerator;
            this.tokenUserService = tokenUserService;
        }
        public async Task<Result> GetLoginUserQuery(LoginDto loginDto)
        {
            loginDto.SetPassword(cryptography);
            var userLogged = await userRepository.Authenticate(loginDto);
            if (userLogged == null)
            {
                throw new ValidationException("Datos de usuario incorrecto");
            }

            if (userLogged.ActiveAccount == false)
            {
                throw new ValidationException("Su cuenta no se encuentra activada");
            }
            userLogged.Img = GetAvatar(userLogged.Img);
            int idprofile = await profileUserRepository.GetProfileByUser(userLogged.Id);
            
            userLogged.SetPhotoUserDefault(appSettings.URL_PHOTO_USER_DEFAULT);
            userLogged.SetPhotoCompanyDefault(appSettings.URL_PHOTO_COMPANY_DEFAULT);
            ProfileGenerator profileGenerator = new ProfileGenerator(userLogged, null);

            var profileUser = profileGenerator.GetUserProfile(tokenGenerator);
            TokenUserPostulant tokenUser = new TokenUserPostulant
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


        public string GetAvatar(string url)
        {
            string img = "";
            if (url != null)
            {
                var file = url;
                if (File.Exists(file))
                {
                    var buffer = File.ReadAllBytes(file);
                    img = $"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}";
                }
            }

            return img;
        }
    }
}
