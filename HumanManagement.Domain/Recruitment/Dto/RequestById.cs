using System;
using System.Collections.Generic;

using HumanManagement.Domain.Utils.Dto;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class RequestById
    {
		public int nid_request { get; set; }
		public int nid_company { get; set; }
		public string company { get; set; }
		public int nid_applicant { get; set; }
		public int nid_category { get; set; }
        public string scategory { get; set; }
        public string fullname { get; set; }
		public int nid_charge { get; set; }
		public string snamecharge { get; set; }
		public int nid_employment { get; set; }
		public string sname { get; set; }
		public decimal nsalary { get; set; }
		public DateTime dregister { get; set; }
		public int nminimumage { get; set; }
		public int nmaximumage { get; set; }
		public int nid_sex { get; set; }
		public string ssex { get; set; }
		public int nid_englishexp { get; set; }
		public string senglishexp { get; set; }
		public bool banotherlanguage { get; set; }
		public string sanotherlanguagename { get; set; }
		public int nid_academiclevel { get; set; }
		public string sacademiclevel { get; set; }
		public string sotheracademiclevel { get; set; }
		public string specialtyrequired { get; set; }
		public string sotherspecialty { get; set; }
		public string sjustification { get; set; }
		public string sknowledge { get; set; }
		public string sabilities { get; set; }
		public string sfunctions { get; set; }
		public string schedule { get; set; }
		public int nid_worksystem { get; set; }
		public string sworksystem { get; set; }
		public int nid_modalitycontracting { get; set; }
		public string smodalitycontracting { get; set; }
		public decimal nvariableremuneration { get; set; }
		public int nextrahours { get; set; }
		public int nid_typerequest { get; set; }
		public int nid_replacement_employee { get; set; }
		public string styperequest { get; set; }
		public int ncontracttime { get; set; }
		public int nvacancy { get; set; }
		public int nid_nivel { get; set; }
        public int chargerequired { get; set; }
        public int ntype { get; set; }
		public int state { get; set; }
		public DateTime dfinish_date { get; set; }
        public bool isSuitableForDisabled { get; set; }
        public int nidsede { get; set; }
        public int nid_location { get; set; }
        public string scareer { get; set; }
        public int nidgrade { get; set; }
        public int nid_department_sede { get; set; }
		public int nid_province_sede { get; set; }
		public int niddistrict_sede { get; set; }
		public string saddress_sede { get; set; }
        public string ssede { get; set; }
        public string sgrade { get; set; }
        
        public string semail { get; set; }
        public string sphone { get; set; }
		public string sphoto_url { get; set; }

		public int nid_profile_aprovver { get; set; }
        public string scomment { get; set; }
        public int nid_company_position { get; set; }
		public int nid_area_position { get; set; }
		public string scareer_post { get; set; }
		public int idgrade_post { get; set; }
		public string scommentfirstmonth { get; set; }
		public string scommentfirstyear { get; set; }
        public string sgrade_post { get; set; }
		public string scompany_position { get; set; }
		public string sarea_position { get; set; }
        public string slocation { get; set; }
		public List<LanguageSolDto> lstLanguages { get; set; }
		public int nid_group { get; set; }
		public decimal ngroosssalary { get; set; }
		public List<PostgradoDto> lstPostgrado { get; set; }
		public List<PostgradoDto> lstPregrado { get; set; }
		public int publicado { get; set; }
		public bool newPosition { get; set; }
        public string nameNewCharge { get; set; }
    }
}
