using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Postulant.Person.Models
{
    public class PersonModelPostulant : BaseModel.BaseModel
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

        [Column("sdocumentnumber")]
        public string DocumentNumber { get; set; }

        [Column("spassport")]
        public string Passport { get; set; }

        [Column("dbirthdate")]
        public DateTime? BirthDate { get; set; }

        

        [Column("nid_nationality")]
        public int IdNationality { get; set; }

        [Column("nid_civilstatus")]
        public int IdCivilStatus { get; set; }

        [Column("bitisnotdomiciled")]
        public int IsNoDomiciled { get; set; }

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

        [Column("scvfolder")]
        public string CvFolder { get; set; }

        [Column("scvname")]
        public string CvName { get; set; }

        [Column("saddress")]
        public string Address { get; set; }

        [Column("nid_district")]
        public int? IdDistrict { get; set; }

        [Column("bhavedriverlicense")]
        public bool HaveDriverLicense { get; set; }

        [Column("slicenceDrive")]
        public string LicenceDrive { get; set; }

        [Column("bhaveownmobility")]
        public bool HaveOwnMobility { get; set; }

        [Column("nid_type_document")]
        public int IdTypeDocument { get; set; }

        [Column("scellphone")]
        public string CellPhone { get; set; }

        [Column("sanotherphone")]
        public string AnotherPhone { get; set; }

        [Column("niddepartmentlocation")]
        public int IdDepartmentLocation { get; set; }

        [Column("nidprovincelocation")]
        public int IdProvinceLocation { get; set; }

        [Column("niddistrictlocation")]
        public int IdDistrictLocation { get; set; }
        public PersonModelPostulant()
        {
            IsNoDomiciled = 1;
        }
        public string GetUserName()
        {
            return $"{FirstName.Substring(0, 1)}{LastName}";
        }



        [Column("scodepayroll")]
        public string scodepayroll { get; set; }
        [Column("scodelocation")]
        public string scodelocation { get; set; }
        [Column("salaryref")]
        public decimal? salaryref { get; set; }
        [Column("schedule")]
        public string schedule { get; set; }
        [Column("sfinancialentitycode")]
        public string sfinancialentitycode { get; set; }
        [Column("sentityaccount")]
        public string sentityaccount { get; set; }
        [Column("sorigincodbankrem")]
        public string sorigincodbankrem { get; set; }
        [Column("sorigincodbankcts")]
        public string sorigincodbankcts { get; set; }
        [Column("scodeafp")]
        public string scodeafp { get; set; }
        [Column("ssalarycurrency")]
        public int? ssalarycurrency { get; set; }
        [Column("sctscurrency")]
        public int? sctscurrency { get; set; }
        [Column("scodbankcts")]
        public string scodbankcts { get; set; }
        [Column("sctsaccount")]
        public string sctsaccount { get; set; }
        [Column("sdoctypebcp")]
        public int? sdoctypebcp { get; set; }
        [Column("bintegralremuneration")]
        public bool? bintegralremuneration { get; set; }
        [Column("bnodomiciliado")]
        public bool? bnodomiciliado { get; set; }
        [Column("stypesalaryaccount")]
        public string stypesalaryaccount { get; set; }
        [Column("bfifthdiscount")]
        public bool? bfifthdiscount { get; set; }
        [Column("bafpmixed")]
        public bool? bafpmixed { get; set; }
        [Column("bisonexactus")]
        public bool? bisonexactus { get; set; }

        [Column("urlprofesional")]
        public string UrlProfesional { get; set; }
        
        [Column("dincomecountry")]
        public DateTime? IncomeCountry { get; set; }
        [Column("scuspp")]
        public string Cuspp { get; set; }
        [Column("dendposition")]
        public DateTime? EndPosition { get; set; }
        [Column("dstartposition")]
        public DateTime? StartPosition { get; set; }
    }
}
