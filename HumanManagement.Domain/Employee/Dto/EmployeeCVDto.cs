using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class EmployeeCVDto
    {
        public int nid_person { get; set; }
        public int nid_employee { get; set; }
        public string scodperson { get; set; }
        public string sidentification { get; set; }
        public string scodemployee { get; set; }
        public string snames { get; set; }
        public string ssurnames { get; set; }
        public string ssexo { get; set; }
        public string scivil { get; set; }
        public string semail { get; set; }
        public string? snamecharge { get; set; }
        public string sfullname { get; set; }
        public string sstate { get; set; }
        public DateTime? dbirthdate { get; set; }
        public int nedad { get; set; }
        public string saddress { get; set; }
        public string phone { get; set; }
        public string subigeo { get; set; }
        public string simg { get; set; }

        public string scompany { get; set; }
        public string snamearea { get; set; }
        public string ssede { get; set; }
        public int nid_boss_real { get; set; }
        public string sjefe { get; set; }
        public DateTime dadmissiondate { get; set; }
        public string sannexed { get; set; }
        public string scorporatemail { get; set; }
        public string seps { get; set; }
        public string sfesalud { get; set; }
        public string spracticante { get; set; }
        public string safp { get; set; }
        public string ssctr { get; set; }
        public string svidaley { get; set; }
        public string slastname_partner { get; set; }
        public string smotherlastname_partner { get; set; }
        public string snamewife_partner { get; set; }

        public string sbloodtype { get; set; }
        public string spassport { get; set; }
        public string snationality { get; set; }
        public DateTime? dcountryentrydate { get; set; }
        public string sdrivinglicense { get; set; }
        public string sheavymachinerylicense { get; set; }

        public DateTime? ddateofmarriage { get; set; }

        public string namegerencia { get; set; }
        public string namearea     { get; set; }
        public string namesubarea { get; set; }


        public string nameareacc { get; set; }

        public string su_entsegvida { get; set; }
        public string su_planeps    { get; set; }
        public string su_plansegpri { get; set; }
        public string SCTR { get; set; }
        public string PLAN_SEGURO_PRACT { get; set; }
        public string safp_code { get; set; }




        public List<ListJobDto> listaJobs { get; set; } = new List<ListJobDto>();
        public List<StudientEmployeeDto> listaStudients { get; set; } = new List<StudientEmployeeDto>();
        public List<ListSonDto> listaSons { get; set; } = new List<ListSonDto>();



    }
}
