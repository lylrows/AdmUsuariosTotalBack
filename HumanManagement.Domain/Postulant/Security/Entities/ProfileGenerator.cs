
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.Postulant.Security.Entities
{
    public class ProfileGenerator
    {
        private ManagerResource managerResource;
        private UserLogged userLogged;
        public ProfileGenerator(UserLogged userLogged, List<ProfileResourceDto> profileRespurceList)
        {
            this.userLogged = userLogged;
            managerResource = new ManagerResource(profileRespurceList);
        }

        public UserProfileDto GetUserProfile(ITokenGenerator tokenGenerator)
        {
            
            return new UserProfileDto
            {
                User = userLogged,
                Token = tokenGenerator.Generate(userLogged.Id),
                TokenLife = tokenGenerator.GetTokenLife(),
                IsLoginOk = true,
                Menu = null
            };
        }
    }
}
