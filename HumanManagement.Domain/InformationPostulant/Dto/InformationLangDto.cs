using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationLangDto
    {
        public int? Id { get; set; }
        public int IdPostulant { get; set; }
        public string Lang { get; set; }
        public string LevelOral { get; set; }
        public string LevelWritten { get; set; }
        public string LevelReading { get; set; }

        public int IdLanguage { get; set; } 
        public int IdWrittenLevel{ get; set; } 
        public int IdOralLevel { get; set; }
    }
}
