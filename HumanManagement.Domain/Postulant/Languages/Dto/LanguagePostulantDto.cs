using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Languages.Dto
{
    public class LanguagePostulantDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public int? IdLanguagePostulant { get; set; }
        public string DescripcionLang { get; set; }
        public int? IdWrittenLeven { get; set; }
        public string DescriptionWrittenLeven { get; set; }
        public int? IdOralLeven { get; set; }

        public string DescriptionOralLeven { get; set; }
        public bool Active { get; set; }
    }
}
