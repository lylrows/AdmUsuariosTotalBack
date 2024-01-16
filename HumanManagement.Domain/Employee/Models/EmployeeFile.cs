using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Employee.Models
{
    public class EmployeeFile
    {
        [Column("nid_employee_file")]
        public int Id { get; set; }

        [Column("nid_employee")]
        public int IdEmployee { get; set; }

        [Column("nvacationdays")]
        public int? VacationDays { get; set; }

        [Column("npendingvacations")]
        public int? PendingVacations { get; set; }

        [Column("nadditionalvacations")]
        public int? AdditionalVacations { get; set; }

        [Column("dnextevaluation")]
        public DateTime? NextEvaluation { get; set; }

        [Column("nreferencesalary")]
        public int? ReferenceSalary { get; set; }

        [Column("nid_paymentmethod")]
        public int? IdPaymentMethod { get; set; }

        [Column("nid_financialentity")]
        public int? IdFinancialEntity { get; set; }

        [Column("sentityaccount")]
        public string EntityAccount { get; set; }

        [Column("nid_schedule")]
        public int? IdSchedule { get; set; }

        [Column("nid_originbank")]
        public int? IdOriginBank { get; set; }

        [Column("nid_ctsoriginbank")]
        public int? IdCtsoriginBank { get; set; }

        [Column("nid_salecategory")]
        public int? IdSaleCategory { get; set; }

        [Column("nid_afp")]
        public int? IdAfp { get; set; }

        [Column("bsalarycurrency")]
        public bool IsSalaryCurrency { get; set; }

        [Column("bctscurrency")]
        public bool IsctsCurrency { get; set; }

        [Column("sctsaccount")]
        public string CtsSccount { get; set; }

        [Column("nid_cidtype")]
        public int? nid_cidtype { get; set; }

        [Column("bitsray")]
        public bool IsItsray { get; set; }

        [Column("nid_accounttype")]
        public int? IdAccountType { get; set; }

        [Column("bdoesnotapplyqta")]
        public bool IsDoesNotApplyqta { get; set; }

        [Column("bmixedafp")]
        public bool IsMixedAfp { get; set; }

        [Column("nid_typedeposit")]
        public int? IdTypeDeposit { get; set; }

        [Column("bprivateinsuranceentity")]
        public bool? IsPrivateInsuranceEntity { get; set; }

        [Column("nepsdependent")]
        public int? EpsDependent { get; set; }

        [Column("ndependientesseguroprivado")]
        public int? DependientEsseguroPrivado { get; set; }

        [Column("nid_epsentity")]
        public int? IdEpsEntity { get; set; }

        [Column("nid_sctrpensionentity")]
        public int? IdSctrPensionentity { get; set; }

        [Column("nid_sctrhealthentity")]
        public int? IdSctrhealthEntity { get; set; }

        [Column("nid_lifeinsuranceentity")]
        public int? IdLifeInsurancEntity { get; set; }

        [Column("dprivateinsuranceenddate")]
        public DateTime? PrivateInsuranceendDate { get; set; }

        [Column("dlifeinsurancestartdate")]
        public DateTime? LifeInsuranceStartDate { get; set; }

        [Column("id_epsplan")]
        public int? IdEpsPlan { get; set; }

        [Column("nid_safeplan")]
        public int IdSafePlan { get; set; }

        [Column("nsctrpensionindicator")]
        public int? SctrPensionIndicator { get; set; }

        [Column("nsctrhealthindicator")]
        public int? SctrHealthIndicator { get; set; }

        [Column("nprivatesecuresctrindicator")]
        public int? PrivateSecureSctrIndicator { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int IdUserRegister { get; set; }

        [Column("dupdate")]
        public DateTime DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int IdUserUpdate { get; set; }
        public virtual EmployeeModel Employee { get; set; }
    }
}
