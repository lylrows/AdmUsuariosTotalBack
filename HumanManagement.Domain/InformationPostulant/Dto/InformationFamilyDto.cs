using HumanManagement.Domain.Utils.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationFamilyDto
    {
        public int? Id { get; set; }
        public string Kinship { get; set; }
        public int IdPostulant { get; set; }
        public int IdEvaluation { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string Age { get; set; }
        public string Ocupation { get; set; }
        public string Company { get; set; }

        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string FamilyType { get; set; }
        public string DocumentNumber { get; set; }
        public string TypeDocument { get; set; }
        public InformationFilesDto InformationFile { get; set; }
    }
}
