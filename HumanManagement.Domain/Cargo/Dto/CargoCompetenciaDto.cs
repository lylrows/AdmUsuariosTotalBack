using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Cargo.Dto
{
    public class CargoCompetenciaDto
    {
        public int Id { get; set; }
        public int NidSelected { get; set; }
        public string NameProficiency { get; set; }
        public string DescriptionProficiency { get; set; }
        public string DescriptionLevel1 { get; set; }
        public string DescriptionLevel2 { get; set; }
        public string DescriptionLevel3 { get; set; }
        public string DescriptionLevel4 { get; set; }
        public int IdCharge { get; set; }
        public int IdMof { get; set; }
        public int IdLevel { get; set; }
        public string NameCharge { get; set; }
        public int IdRequest { get; set; }
        public int UserRegister { get; set; }
        public bool Required { get; set; }
    }
}
