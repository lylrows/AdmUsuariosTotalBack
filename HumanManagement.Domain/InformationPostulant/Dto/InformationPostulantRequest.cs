using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationPostulantRequest
    {
        public int IdPostulantRequest { get; set; }
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string BirthDate { get; set; }
        public int IdCompany { get; set; }
        public int IdManagement { get; set; }
        public int IdArea { get; set; }
        public int IdSubArea { get; set; }
        public int IdCostCenter { get; set; }
        public string Position { get; set; }
        public string IncomeDate { get; set; }
        public string EndDate { get; set; }
        public int ContractType { get; set; }
        public int VacantType { get; set; }
        public string Schedule { get; set; }
        public string Boss { get; set; }
        public int IdBoss { get; set; }
        public int IdSalaryCategory { get; set; }
        public int IdCampus { get; set; }
        public int User { get; set; }
        public bool Confirmed { get; set; }
    }

    public class FilterInformationPostulantRequest
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public string Type { get; set; }
    }
}
