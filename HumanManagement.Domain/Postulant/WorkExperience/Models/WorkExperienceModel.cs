using System.ComponentModel.DataAnnotations.Schema;


namespace HumanManagement.Domain.Postulant.WorkExperience.Models
{
    public class WorkExperienceModel: BaseModel.BaseModel
    {
        [Column("nidworkexperience")]
        public int Id { get; set; }

        [Column("nidperson")]
        public int IdPerson { get; set; }

        [Column("scompany")]
        public string Company { get; set; }

        [Column("nidactivity")]
        public int IdActivity { get; set; }

        [Column("sstand")]
        public string Stand { get; set; }

        [Column("nidexperiencelevel")]
        public int IdExperienceLevel { get; set; }

        [Column("nidpositionarea")]
        public int IdPositionArea { get; set; }

        [Column("subarea")]
        public string SubArea { get; set; }

        [Column("nidcountry")]
        public int? IdCountry { get; set; }

        [Column("yearstart")]
        public string YearStart { get; set; }

        [Column("monthstart")]
        public string MonthStart { get; set; }

        [Column("yearend")]
        public string YearEnd { get; set; }

        [Column("monthend")]
        public string MonthEnd { get; set; }

        [Column("sdescriptionresponsabilities")]
        public string DescriptionResponsabilities { get; set; }

        [Column("nidpeoplecharge")]
        public int? IdPeopleCharge { get; set; }

        [Column("nsalary")]
        public decimal? Salary { get; set; }

        [Column("bpresent")]
        public bool? Present { get; set; }
    }
}
