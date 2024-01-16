using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationLangModel : BaseModel.BaseModel
    {
        [Column("nidlanguagepostulant")]
        public int Id { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("slang")]
        public string Lang { get; set; }

        [Column("sleveloral")]
        public string LevelOral { get; set; }

        [Column("slevelwritten")]
        public string LevelWritten { get; set; }

        [Column("slevelreading")]
        public string LevelReading { get; set; }
        [Column("nidlanguage")]
        public int IdLanguage      { get; set; }
        [Column("nidwrittenleven")]
        public int IdWrittenLevel  { get; set; }
        [Column("nidoralleven")]
        public int IdOralLevel { get; set; }


    }
}
