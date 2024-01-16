using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
	public class EmployeeDetailtDto
	{
		public int nid_employee { get; set; }
		public string scodemployee { get; set; }
		public int nid_person { get; set; }
		public int? nid_position { get; set; }
		public int? nid_charge { get; set; }
		public string snamecharge { get; set; }
		public int? niduppercharge { get; set; }

		public int? nid_area { get; set; }
		public int? nid_company { get; set; }
		public string plaza { get; set; }
		public int? nid_costcenter { get; set; }
		public DateTime? ddateoffirstadmission { get; set; }
		public DateTime? dadmissiondate { get; set; }
		public DateTime? ddeparturedate { get; set; }
		public int? nid_payroll { get; set; }
		public bool? bdependents { get; set; }
		public string snit { get; set; }
		public DateTime? dcompanyseniority { get; set; }
		public DateTime? dgovernmentseniority { get; set; }
		public int? nid_state { get; set; }
		public string sinsurednumbers { get; set; }
		public string stypeinsurance { get; set; }
		public string shealthpermit { get; set; }
		public int? nid_boss { get; set; }
		public string snameboss { get; set; }
		public string smerit { get; set; }
		public string sdemerit { get; set; }
		public DateTime dregister { get; set; }
		public string scorporatemail { get; set; }
		public string sannexed { get; set; }
		public string sheavymachinerylicense { get; set; }
		public string sddriverlicense { get;set;}
		public string snamewife_partner { get; set; }
		public string slastname_partner { get; set; }
		public string smotherlastname_partner { get; set; }
		public DateTime? ddateofmarriage { get;set;}
		public string scovidcard { get; set; }
		public bool bhassignature { get; set; }
		public string ssignature { get; set; }
		public int? nid_sede { get; set; }
        public int? nid_boss_real { get; set; }
        public string sname_boss_real { get; set; }
        public int IdGerencia { get; set; }
		public int IdArea { get; set; }
		public int IdSubArea { get; set; }
        public string scodsede { get; set; }

		public string safp_code			{ get; set; }
		public int? su_entsegvida		{ get; set; }
		public int? su_planeps		{ get; set; }
		public int? su_plansegpri		{ get; set; }
		public int? su_sctrsalud		{ get; set; }
		public int? su_entsegpract { get; set; }

        public string scentercost { get; set; }


    }
}
