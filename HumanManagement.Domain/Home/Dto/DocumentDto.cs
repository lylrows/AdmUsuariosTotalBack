using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Home.Dto
{
    public class DocumentDto
    {
        public int Id { get; set; }

        public int IdCategory { get; set; }
        public int IdCompany { get; set; }
        public int? IdSubCategory { get; set; }
        public string NameCompany { get; set; }
        public string NameCategory { get; set; }
        public string NameSubCategory { get; set; }
        public string Description { get; set; }

        public string Filename { get; set; }

        public string Filenamefolder { get; set; }

        public bool Active { get; set; }

        public DateTime DateRegister { get; set; }

        public int UserRegister { get; set; }

        public DateTime? DateUpdate { get; set; }

        public int? UserUpdate { get; set; }
    }
}
