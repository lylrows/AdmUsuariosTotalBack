
namespace HumanManagement.Domain.Postulant.WorkExperience.Dto
{
    public class WorkExperienceDto
    { 
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string Company { get; set; }
        public int IdActivity { get; set; }
        public string Stand { get; set; } 
        public int IdExperienceLevel { get; set; }
        public int IdPositionArea { get; set; }
        
        public string subArea { get; set; }
        public int? IdCountry { get; set; }
        public string YearStart { get; set; }
        public string MonthStart { get; set; }
        public string YearEnd { get; set; }

        public string MonthEnd { get; set; }
        public string DescriptionResponsabilities { get; set; }
        public int? IdPeopleCharge { get; set; }
        public string Salary { get; set; }
        public bool? Present { get; set; }
        public bool Active { get; set; }
    }
}
