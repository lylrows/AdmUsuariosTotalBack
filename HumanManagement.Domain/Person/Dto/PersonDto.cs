using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Person.Dto
{
    public class PersonDto
    {
		public int nid_person { get; set; }
		public string scodperson { get; set; }
		public string sfirstname { get; set; }
		public string ssecondname { get; set; }
		public string slastname { get; set; }
		public string smotherlastname { get; set; }
		public string semail { get; set; }
		public int? nid_sex { get; set; }
		public string sbloodtype { get; set; }
		public string sidentification { get; set; }
		public string spassport { get; set; }
		public DateTime? dbirthdate { get; set; }
		public int? nid_nationality { get; set; }
		public string snationality { get; set; }
		public string saddress { get; set; }
		public int? nid_civilstatus { get; set; }
		public bool? bitisnotdomiciled { get; set; }
		public string sdrivinglicense { get; set; }
		public DateTime? duniversitygraduationdate { get; set; }
		public DateTime? dcountryentrydate { get; set; }
		public string smedicalstaff { get; set; }
		public int? nid_active { get; set; }
		public string sphonenumber { get; set; }
		public string simg { get; set; }
		public string CvName { get; set; }
		public byte[] CvFile { get; set; }
		public string ContentType { get; set; }
		public string email { get; set; }
		public string semergency_contact_name { get; set; }
		public string semergency_contact_phone { get; set; }
		public string scivil_status { get; set; }
		public string sage { get; set; }

        public int nid_postulant { get; set; }
    }
}
