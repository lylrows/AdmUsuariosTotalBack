
namespace HumanManagement.Domain.Person.Dto
{
    public class PostulantDto
    {
        public int? Id { get; set; }
        public int IdPostulant { get; set; }
        public int IdPerson { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string DateRegister { get; set; }
        public string CellPhone { get; set; }
        public string CvName { get; set; }
        public string CvGrupoFe { get; set; }
        public string CvAttached { get; set; }
        public string State { get; set; }
        public string Skill { get; set; }
        public int TotalSkills { get; set; }
        public string Position { get; set; }
        public int IdJob { get; set; }

        public string Gender { get; set; }
        public string DocumentNumber { get; set; }
        public string CivilStatus { get; set; }
        public string LevelStudy { get; set; }
        public string WorkExperience { get; set; }
        public int IdPositionCurrently { get; set; }
        public decimal MinimunSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public string SalaryPreference { get; set; }
        public string Address { get; set; }
        public int Flag_coincide_grado { get; set; }
        public string Scareer_position { get; set; }
        public string Scareer_postulant { get; set; }
        public double PorcentajeAsertividad { get; set; }
        public decimal SalaryPostulant { get; set; }
        public int AgePostulant { get; set; }
        public int NidSex { get; set; }
        public int CurrentWorking { get; set; }
        public string Universities { get; set; }
        public string NivelesEstudio { get; set; }
    }

    public class PostulantInternalDto
    {
        public int IdPostulant { get; set; }
        public int IdPerson { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string DateRegister { get; set; }
        public string CellPhone { get; set; }
        public string CvName { get; set; }
        public string CvGrupoFe { get; set; }
        public string CvAttached { get; set; }
        public string State { get; set; }
        public string Skill { get; set; }
        public int TotalSkills { get; set; }
        public string Position { get; set; }
        public int IdJob { get; set; }

        public string Gender { get; set; }
        public string DocumentNumber { get; set; }
        public string CivilStatus { get; set; }
        public string LevelStudy { get; set; }
        public string WorkExperience { get; set; }
        public decimal MinimunSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public string Address { get; set; }
        public int IdPositionCurrently { get; set; }
    }
}
