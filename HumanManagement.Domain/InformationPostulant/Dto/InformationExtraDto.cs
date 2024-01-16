using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationExtraDto
    {
        public int? Id { get; set; }
        public int IdPostulant { get; set; }
        public string PlaceOfBirth { get; set; }
        public bool? CreateBcp { get; set; }
        public string RucNumber { get; set; }
        public string BankOpen { get; set; }
        public string Age { get; set; }
        public string Afp { get; set; }
        public string BankAfp { get; set; }
        public string Company { get; set; }
        public bool? Moto { get; set; }
        public bool? Auto { get; set; }
        public string CategoryBrevete { get; set; } 
        public string NroReferencia { get; set; }
        public string TypeSangre { get; set; }
        public int? IdDocumentType { get; set; }
        public string IncomeCountryDate { get; set; }
        public string BankHaberes { get; set; }
        public string NombreContacto { get; set; }
        public string NroReferenciaContacto { get; set; }
        public string ParentescoContacto { get; set; }
        public bool? Disclaimer { get; set; }
        public bool? HasMobility { get; set; }
        public bool? HasDisability { get; set; }
        public bool? Sent { get; set; }
    }
}
