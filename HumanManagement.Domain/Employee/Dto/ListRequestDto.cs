using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class ListRequestDto
    {
        public int nid_request { get; set; }
        public int nid_typerequest { get; set; }
        public string styperequest { get; set; }
        public int nid_collaborator { get; set; }
        public string scollaborator { get; set; }
        public int nid_approver { get; set; }
        public string sapprover { get; set; }
		public DateTime dregister { get; set; }
        public int nstate { get; set; }
        public string sstate { get; set; }
		public int ntypeseccion { get; set; }
		public string ssection { get; set; }
		public int ntypeaction { get; set; }
		public string stypeaction { get; set; }
		public string scomment { get; set; }
		public string dni { get; set; }
		public string periodo { get; set; }
		public int IdGerencia { get; set; }
		public string Gerencia { get; set; }
		public int IdArea { get; set; }
		public string Area { get; set; }
		public int IdSubArea { get; set; }
		public string SubArea { get; set; }


	}

	public class RequestDetailDto
	{
		public int nid_requestdetail { get; set; }
		public int nid_request { get; set; }
		public int nid_collaborator { get; set; }
		public string scollaborator { get; set; }
		public int? nid_approver { get; set; }
		public string description { get; set; }
		public int? nid_address { get; set; }
		public string saddress { get; set; }
		public int? nid_district { get; set; }
		public string sdistrict { get; set; }
		public string sprovince { get; set; }
		public string sdepartment { get; set; }
		public int? nid_phone { get; set; }
		public string phone { get; set; }
		public int? nid_statecivil { get; set; }
		public string scivil { get; set; }
		public int? nid_education { get; set; }
		public int? nid_instruction { get; set; }
		public string sinstruccion { get; set; }
		public string sstudy_center { get; set; }
		public string scurrent_cycle { get; set; }
		public DateTime? dateStart { get; set; }
		public DateTime? dateEnd { get; set; }
		public string snamewife_partner { get; set; }
		public DateTime dregister { get; set; }
		public string slastname_partnet { get; set; }
		public string smotherlastname_partnet { get; set; }
		public DateTime? ddateofmarriage { get; set; }
		public int? nid_son { get; set; }
		public string sfullname { get; set; }
		public DateTime? ddateofbirth { get; set; }
		public int? nyear { get; set; }
		public int? ntypeaction { get; set; }
		public int? ntypeseccion { get; set; }
		public string sheavymachinerylicense { get; set; }
		public string sddriverlicense { get; set; }
		public string slastname { get; set; }
		public string smotherslastname { get; set; }
		public string sFile { get; set; }
		public int? nmonth { get;set;}
		public string simg { get; set; }
		public string scarreer { get; set; }

	}

    public class RequestDto
    {
        public int nid_request { get; set; }
        public int nid_typerequest { get; set; }
        public int nid_collaborator { get; set; }
        public int nstate { get; set; }
        public DateTime dregister { get; set; }
    }

}
