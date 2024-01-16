using System;
using System.Collections.Generic;

namespace HumanManagement.Domain.Postulant.Person.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string CodPerson { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondlastName { get; set; }
        public string MotherLastName { get; set; }
        public string Email { get; set; }
        public int IdSex { get; set; }
        public string Sex { get; set; }
        public string SexComplete { get; set; }
        public string BloodType { get; set; }
        public string DocumentNumber { get; set; }
        public string Passport { get; set; }
        public string BirthDate { get; set; }
        public int IdNationality { get; set; }
        public string Nationality { get; set; }
        public int IdCivilStatus { get; set; }
        public string CivilStatus { get; set; }
        public bool IsNoDomiciled { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime? UniversityGraduationDate { get; set; }
        public DateTime? CountryentryDate { get; set; }
        public string MedicalStaff { get; set; }
        public int IdActive { get; set; }
        public string Img { get; set; }
        public string CvFolder { get; set; }
        public string CvName { get; set; }
        public byte[] CvFile { get; set; }
        public string ContentType { get; set; }
        public string Address { get; set; }
        public int IdDistrict { get; set; }
        public bool HaveDriverLicense { get; set; }
        public string LicenceDrive { get; set; }
        
        public bool HaveOwnMobility { get; set; }
        public string CellPhone { get; set; }
        public string AnotherPhone { get; set; }
        public int? IdTypeDocument { get; set; }
        public string TypeDocument { get; set; }
        public int IdDepartmentLocation { get; set; }
        public int IdProvinceLocation { get; set; }
        public int IdDistrictLocation { get; set; }
        public int IdUser { get; set; }
        public DateTime? DateApplicant { get; set; }
        public string SalaryPreference { get; set; }
        public string UrlProfesional { get; set; }
        public List<LoadedWorkExperienceDto> WorkExperience { get; set; }
        public List<LoadedStudyDto> StudyDto { get; set; }
        public List<LangDto> LangDto { get; set; }
        public string LaboralObjective { get; set; }
        public string DocumentType { get; set; }
        public string SalaryPretesion { get; set; }
        public string Skills { get; set; }
    }

    public class LoadedWorkExperienceDto
    {
        public string Position { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Industria { get; set; }
        public string Descripcion { get; set; }
        public bool? Present { get; set; }
    }

    public class LoadedStudyDto
    {
        public string Institution { get; set; }
        public string Titulo { get; set; }
        public string State { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
        public string Country { get; set; }
        public string Level { get; set; }
        public string Carreer { get; set; }
        public bool? Present { get; set; }

    }

    public class LangDto
    {
        public string Lang { get; set; }
        public string Level { get; set; }
    }
}
