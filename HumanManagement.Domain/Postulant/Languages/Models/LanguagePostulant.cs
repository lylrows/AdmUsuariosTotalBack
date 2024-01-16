using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.Languages.Models
{
    public class LanguagePostulant : BaseModel.BaseModel
    {
        [Column("nidlanguage")]
        public int Id { get; set; }

        [Column("nidperson")]
        public int IdPerson { get; set; }

        [Column("nidlanguagepostulant")]
        public int? IdLanguagePostulant { get; set; }

        [Column("nidwrittenleven")]
        public int? IdWrittenLeven { get; set; }

        [Column("nidoralleven")]
        public int? IdOralLeven { get; set; }
    }
}
