using HumanManagement.Domain.Person.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Employee.Models
{
    public class EmployeeModel
    {
        [Column("nid_employee")]
        public int Id { get; set; }

        [Column("scodemployee")]
        public string CodEmployee { get; set; }
        
        [Column("nid_person")]
        public int IdPerson { get; set; }

        [Column("nid_position")]
        public int IdPosition { get; set; }

        [Column("plaza")]
        public string plaza { get; set; }

        [Column("nid_costcenter")]
        public int IdCostcenter { get; set; }

        [Column("ddateoffirstadmission")]
        public DateTime? DateOffirstAdmission { get; set; }

        [Column("dadmissiondate")]
        public DateTime AdmissionDate { get; set; }

        [Column("ddeparturedate")]
        public DateTime? DepartureDate { get; set; }

        [Column("nid_payroll")]
        public int IdPayroll { get; set; }

        [Column("bdependents")]
        public bool IsDependents { get; set; }

        [Column("snit")]
        public string Nit { get; set; }

        [Column("dcompanyseniority")]
        public DateTime? CompanySeniority { get; set; }

        [Column("dgovernmentseniority")]
        public DateTime? GovernmentSeniority { get; set; }

        [Column("nid_state")]
        public int IdState { get; set; }

        [Column("sinsurednumbers")]
        public string InsuredNumbers { get; set; }

        [Column("stypeinsurance")]
        public string TypeInsurance { get; set; }

        [Column("shealthpermit")]
        public string HealthPermit { get; set; }

        [Column("dregister")]
        public DateTime? DateRegister { get; set; }

        [Column("nuserregister")]
        public int? IdUserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? IdUserUpdate { get; set; }

        [Column("nid_company")]
        public int IdCompany { get; set; }

        [Column("smerit")]
        public string Merit { get; set; }

        [Column("sdemerit")]
        public string Demerit { get; set; }

        [Column("scorporatemail")]
        public string CorporateMail { get; set; }

        [Column("sannexed")]
        public string Annexed { get; set; }

        [Column("sheavymachinerylicense")]
        public string HeavyMachineryLicense { get; set; }

        [Column("sddriverlicense")]
        public string DdriverLicense { get; set; }

        [Column("snamewife_partner")]
        public string NameWifePartner { get; set; }

        [Column("ddateofmarriage")]
        public DateTime? DateofMarriage { get; set; }

        [Column("scovidcard")]
        public string CovidCard { get; set; }

        [Column("bhassignature")]
        public bool? HasSignature { get; set; }

        [Column("ssignature")]
        public string Signature { get; set; }

        [Column("nid_sede")]
        public int? SedeId { get; set; }
        [Column("slastname_partner")]
        public string? LastNamePartner { get; set; }
        [Column("smotherlastname_partner")]
        public string? MotherLastNamePartner { get; set; }
        [Column("nid_boss")]
        public int? BossId { get; set; }
        public virtual PersonModel Person { get; set; }
        [Column("bexistsinexactus")]
        public bool? ExistsInExactus { get; set; }
        [Column("scodsede")]
        public string Sede { get; set; }
        [Column("scentercost")]
        public string CenterCost { get; set; }

        [Column("scode_bank")]
        public string CodeBank { get; set; }

        [Column("saccount_bank")]
        public string AccountBank { get; set; }

        [Column("scciaccount_bank")]
        public string Cciaccount_bank { get; set; }

        [Column("scurrencyaccount_bank")]
        public string CurrencyAccountBank { get; set; }

        [Column("scode_bank_cts")]
        public string CodeBankCts { get; set; }
        [Column("saccount_cts")]
        public string AccountCts { get; set; }
        [Column("scurrency_cts")]
        public string CurrencyCts { get; set; }
        [Column("safp_code")]
        public string AfpCode { get; set; }


        [Column("su_entsegvida")]
        public int? su_entsegvida  { get; set; }
        [Column("su_planeps")]
        public int? su_planeps     { get; set; }
        [Column("su_plansegpri")]
        public int? su_plansegpri  { get; set; }
        [Column("su_sctrsalud")]
        public int? su_sctrsalud   { get; set; }
        [Column("su_entsegpract")]
        public int? su_entsegpract { get; set; }




    }
}
