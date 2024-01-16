using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
	public class RequestInsDto
	{
		public int nid_typerequest { get; set; }
		public int nid_collaborator { get; set; }
		public string description { get; set; }
		public int? nid_address { get; set; }
		public string saddress { get; set; }
		public int? nid_district { get; set; }
		public int? nid_phone { get; set; }
		public string phone { get; set; }
		public int? nid_statecivil { get; set; }
		public int? nid_education { get; set; }
		public int? nid_instruction { get; set; }
		public string sstudy_center { get; set; }
		public string scurrent_cycle { get; set; }
		public DateTime? dateStart { get; set; }
		public DateTime? dateEnd { get; set; }
		public string snamewife_partner { get; set; }
		public string lastname_partner { get; set; }
		public string motherlastname_partner { get; set; }
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
		public int nid_person { get; set; }
		public string scarreer { get; set; }
	}

	public class AcceptRequest
    {
		public int nid_request { get; set; }
		public int nid_emisor { get; set; }
		public int nid_reseptor { get; set; }
		public int nid_area { get; set; }
		public int type { get; set; }
		public string name { get; set; }
		public string dni { get; set; }
		public string charger { get; set; }
		public DateTime date { get; set; }
		public int ntypeseccion { get; set; }
	}

	public class RejectRequest
    {
		public int nid_request { get; set; }
		public int nid_collaborator { get; set; }
		public int nid_reseptor { get; set; }
		public int nid_area { get; set; }
		public int type { get; set; }
		public string scomment { get; set; }
	}

	public class RequestFilterDto
    {
		public int id { get; set; }
		public int idbussines { get; set; }
		public int idgerencia { get; set; }
		public int idarea { get; set; }
		public int nidsubarea { get; set; }
		public int nstate { get; set; }
		public int nid_typerequest { get; set; }
		public int ntypeseccion { get; set; }
		public string dateStart { get; set; }
		public string dateEnd { get; set; }
		public int nid_employee { get; set; }		
	}

	public class UpdateCovidCardDto
    {
		public int nid_employee { get; set; }
    }

	public class InsertRequestDocumentDto
    {
		public int nid_collaborador { get; set; }
		public int? nyear { get; set; }
		public int? nmonth { get; set; }
		public int nid_person { get; set; }
		public int ntypeseccion { get; set; }
        public string stipo_reporte { get; set; }
		public string empresa_nombre { get; set; }
		public string periodo { get; set; }
		public string tipo_solicitud { get; set; }
	}
	public class simplePayload
    {
		public int idEmployee { get; set; }
		public string inputFullname { get; set; }

	}
}
