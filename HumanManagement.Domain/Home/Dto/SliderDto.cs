using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Home.Dto
{
    public class SliderDto
    {
        public int Id { get; set; }
        public int IdType { get; set; }
        public string NameType { get; set; }
        public string Filename { get; set; }
        public string Filenamefolder { get; set; }
        public int Order { get; set; }
        public bool IsImage { get; set; }
        public string UrlImage { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegister { get; set; }
        public int UserRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? UserUpdate { get; set; }
        
    }
}
