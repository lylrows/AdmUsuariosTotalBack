using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class UpdateEmployeeDto
    {
		public int nid_person { get; set; }
		public string scodperson { get; set; }
		public string sfirstname { get; set; }
		public string ssecondname { get; set; }
		public string slastname { get; set; }
		public string smotherlastname { get; set; }
		public string semail { get; set; }
		public int nid_sex { get; set; }
		public string sbloodtype { get; set; }
		public string sidentification { get; set; }
		public string spassport { get; set; }
		public DateTime dbirthdate { get; set; }
		public int nid_nationality { get; set; }
		public int nid_civilstatus { get; set; }
		public bool bitisnotdomiciled { get; set; }
		public string sdrivinglicense { get; set; }
		public DateTime? duniversitygraduationdate { get; set; }
		public DateTime? dcountryentrydate { get; set; }
		public string smedicalstaff { get; set; }
		public int nid_active { get; set; }
		public string simg { get; set; }
		public string email { get; set; }
		public string semergency_contact_name { get; set; }
		public string semergency_contact_phone { get; set; }
		public int nid_employee { get; set; }
		public string scodemployee { get; set; }
		public int nid_position { get; set; }
		public int nid_company { get; set; }
		public string plaza { get; set; }
		public int nid_costcenter { get; set; }
		public DateTime? ddateoffirstadmission { get; set; }
		public DateTime? dadmissiondate { get; set; }
		public DateTime? ddeparturedate { get; set; }
		public int nid_payroll { get; set; }
		public bool bdependents { get; set; }
		public string snit { get; set; }
		public DateTime? dcompanyseniority { get; set; }
		public DateTime? dgovernmentseniority { get; set; }
		public int nid_state { get; set; }
		public string sinsurednumbers { get; set; }
		public string stypeinsurance { get; set; }
		public string shealthpermit { get; set; }

		public string smerit { get; set; }
		public string sdemerit { get; set; }
		public string scorporatemail { get; set; }
		public string sannexed { get; set; }
		public string sheavymachinerylicense { get; set; }
		public string sddriverlicense { get; set; }
		public string snamewife_partner { get; set; }
		public DateTime? ddateofmarriage { get; set; }
		public string scovidcard { get; set; }

		public int nid_employee_file { get; set; }
		public int? nvacationdays { get; set; }
		public int? npendingvacations { get; set; }
		public bool? bsalarycurrency { get; set; }
		public bool? bctscurrency { get; set; }
		public bool? bitsray { get; set; }
		public int nid_safeplan { get; set; }
		public bool bdoesnotapplyqta { get; set; }
		public bool bmixedafp { get; set; }

		public int? nid_sctrpensionentity { get; set; }
		public int? nid_afp { get; set; }
		public int? id_epsplan { get; set; }
		public string slifelaw { get; set; }
		public int? nFesaludPlan { get; set; }
		public int? nInternPlan { get; set; }

		public bool bemployee_file_exist { get; set; }
		public int? nid_sede { get; set; }
        public int? nid_boss_real { get; set; }

        public int idGerencia { get; set; }
        public int idArea { get; set; }
        public int idSubArea { get; set; }
    }
}
