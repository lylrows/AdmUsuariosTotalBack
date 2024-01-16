using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Education.Dto
{
    public class EducationPostulantDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string Carreer { get; set; }
        public int? IdCountry { get; set; }
        public string Country { get; set; }
        public int IdTypeStudy { get; set; }
        public string DescriptionTypeStudy { get; set; }
        public int IdAreaStudy { get; set; }
        public int? IdInstitution { get; set; }
        public string OtherInstitution { get; set; }
        public string Institution { get; set; }
        public int IdState { get; set; }
        public string DescriptionState { get; set; }
        public string MonthStart { get; set; }
        public string YearStart { get; set; }
        public string MonthEnd { get; set; }
        public string YearEnd { get; set; }
        public bool Active { get; set; }
        public bool? Present { get; set; }
    }
}
