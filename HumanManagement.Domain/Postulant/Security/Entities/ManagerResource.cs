using HumanManagement.Domain.Postulant.Security.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.Postulant.Security.Entities
{
    public class ManagerResource
    {
        private List<ProfileResourceDto> profileResourceList;
        public ProfileResourceDto ProfileResource { get; private set; }
        public ManagerResource(List<ProfileResourceDto> profileResourceList)
        {
            this.profileResourceList = profileResourceList;
            ProfileResource = new ProfileResourceDto
            {
                Name = "menu Padre",
                RouteLink = ""
            };
        }

        public void SetResource()
        {
            ProfileResource.Items = SetMenuFather();
        }
        public List<ProfileResourceDto> SetMenuFather()
        {
            List<ProfileResourceDto> menuList = new List<ProfileResourceDto>();
            profileResourceList.ForEach(x =>
            {
                if (x.IdFather == 0)
                {
                    ProfileResourceDto item = new ProfileResourceDto
                    {
                        Name = x.Name,
                        Type = x.Type,
                        SvgIcon = x.SvgIcon,
                        RouteLink = x.RouteLink,
                        Items = SetMenuChild(x.IdResource)
                    };
                    menuList.Add(item);
                }
            });

            return menuList;
        }
        private List<ProfileResourceDto> SetMenuChild(int idMenuFather)
        {
            List<ProfileResourceDto> menuList = new List<ProfileResourceDto>();
            profileResourceList.ForEach(x =>
            {
                if (x.IdFather == idMenuFather)
                {
                    ProfileResourceDto item = new ProfileResourceDto
                    {
                        Name = x.Name,
                        Type = x.Type,
                        SvgIcon = x.SvgIcon,
                        RouteLink = x.RouteLink,
                        Items = SetMenuChild(x.IdResource)
                    };
                    menuList.Add(item);
                }
            });

            return menuList;
        }
    }
}
