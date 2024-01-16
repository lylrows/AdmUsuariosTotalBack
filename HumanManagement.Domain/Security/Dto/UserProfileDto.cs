using System.Collections.Generic;

namespace HumanManagement.Domain.Security.Dto
{
    public class UserProfileDto
    {
        public UserLogged User { get; set; }
        public string Token { get; set; }
        public int TokenLife { get; set; }
        public ProfileResourceDto Menu { get; set; }
        public bool IsLoginOk { get; set; }

    }

    public class UserLogged
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string PathPhoto { get; set; }
        public string UrlPhotoUser { get; set; }
        public string UrlPhotoCompany { get; set; }
        public bool ChangedPassword { get; set; }
        public bool Blocked { get; set; }
        public int nid_position { get; set; }
        public int nid_profile { get; set; }
        public int nid_person { get; set; }
        public int nid_employee { get; set; }
        public string extra_companies { get; set; }
        public int nid_company { get; set; }

        public void SetPhotoUserDefault(string urlPhotoUserDefault)
        {
            if (string.IsNullOrEmpty(UrlPhotoUser))
            {
                UrlPhotoUser = urlPhotoUserDefault;
            }
        }
        public void SetPhotoCompanyDefault(string urlPhotoCompanyDefault)
        {
            if (string.IsNullOrEmpty(UrlPhotoCompany))
            {
                UrlPhotoCompany = urlPhotoCompanyDefault;
            }
        }
    }

    public class ProfileResourceDto
    {
        public int IdResource { get; set; }
        public int IdFather { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SvgIcon { get; set; }
        public string RouteLink { get; set; }

        public int Order { get; set; }
        public List<ProfileResourceDto> Items { get; set; }
        public ProfileResourceDto()
        {
            Items = new List<ProfileResourceDto>();
        }
    }
}
