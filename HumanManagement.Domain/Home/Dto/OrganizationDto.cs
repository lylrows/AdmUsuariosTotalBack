using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Home.Dto
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Filenamefolder { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegister { get; set; }
        public int UserRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? UserUpdate { get; set; }
    }
}
