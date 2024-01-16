using System;
using System.Collections.Generic;
using System.Text;
using HumanManagement.Domain.Utils.Dto;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class RequestDto
    {
        public int IdRequest { get; set; }
        public int IdEmployment { get; set; }
        public int IdCompany { get; set; }
        public int IdCategory { get; set; } 
        public int IdApplicant { get; set; }
        public int IdTypeRequest { get; set; }
        public int? nid_replacement_employee { get; set; }
        public int ntimetyperequest { get; set; }
        public string sjustification { get; set; }
        public int nminimumage { get; set; }
        public int nmaximumage { get; set; }
        public int nid_sex { get; set; }
        public int nid_englishexp { get; set; }
        public bool banotherlanguage { get; set; }
        public string sanotherlanguagename { get; set; }
        public int nid_academiclevel { get; set; }
        public string sotheracademiclevel { get; set; }
        public string specialtyrequired { get; set; }
        public string sotherspecialty { get; set; }
        public string sknowledge { get; set; }
        public string sabilities { get; set; }
        public string sfunctions { get; set; }
        public string schedule { get; set; }
        public int nid_worksystem { get; set; }
        public int nid_modalitycontracting { get; set; }
        public int ncontracttime { get; set; }
        public decimal nsalaryemployment { get; set; }
        public decimal nvariableremuneration { get; set; }
        public int nextrahours { get; set; }
        public string scomment { get; set; }
        public int State { get; set; }
        public int Vacancy { get; set; }
        public int UserRegister { get; set; }
        public string Employment { get; set; }
        public int nid_originarea { get; set; }
        public int nid_nivel { get; set; }
        public int? idcharge { get; set; }
        public bool? newPosition { get; set; }
        public int ntype { get; set; }
        public bool? isSuitableForDisabled { get; set; }
        public string scareer { get; set; }
        public int idgrade { get; set; }
        public int idsede { get; set; }
        public int idlocation { get; set; }
        public int nid_company_position { get; set; }
        public int nid_area_position { get; set; }
        public string scareer_post { get; set; }
        public int idgrade_post { get; set; }
        public string scommentfirstmonth { get; set; }
        public string scommentfirstyear { get; set; }
        public int? optionalJobs { get; set; }
        public int? nid_job { get; set; }
        public List<LanguageSolDto> lstLanguages { get; set; }
        public List<PostgradoDto> lstPostgrado { get; set; }
        public List<PostgradoDto> lstPregrado { get; set; }
        public string sname_newcharge { get; set; }

    }
}
