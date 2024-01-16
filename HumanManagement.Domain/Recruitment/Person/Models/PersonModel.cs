using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Recruitment.Person.Models
{
    public class PersonModel
    {
        [Column("nid_person")]
        public int Id { get; set; }

        [Column("scodperson")]
        public string CodPerson { get; set; }

        [Column("sfirstname")]
        public string FirstName { get; set; }

        [Column("ssecondname")]
        public string SecondName { get; set; }

        [Column("slastname")]
        public string LastName { get; set; }

        [Column("smotherlastname")]
        public string MotherLastName { get; set; }

        [Column("semail")]
        public string Email { get; set; }

        [Column("nid_sex")]
        public int IdSex { get; set; }

        [Column("sbloodtype")]
        public string BloodType { get; set; }

        [Column("sidentification")]
        public string Identification { get; set; }

        [Column("spassport")]
        public string Passport { get; set; }

        [Column("dbirthdate")]
        public string BirthDate { get; set; }


        [Column("nid_nationality")]
        public int IdNationality { get; set; }

        [Column("nid_civilstatus")]
        public int IdCivilStatus { get; set; }

        [Column("bitisnotdomiciled")]
        public bool IsNoDomiciled { get; set; }

        [Column("sdrivinglicense")]
        public string DrivingLicense { get; set; }

        [Column("duniversitygraduationdate")]
        public DateTime? UniversityGraduationDate { get; set; }

        [Column("dcountryentrydate")]
        public DateTime? CountryentryDate { get; set; }

        [Column("smedicalstaff")]
        public string MedicalStaff { get; set; }

        [Column("nid_active")]
        public int IdActive { get; set; }

        [Column("simg")]
        public string Img { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int UserUpdate { get; set; }
        public PersonModel()
        {
            IsNoDomiciled = true;
        }
        public string GetUserName()
        {
            return $"{FirstName.Substring(0, 1)}{LastName}";
        }
    }
}
