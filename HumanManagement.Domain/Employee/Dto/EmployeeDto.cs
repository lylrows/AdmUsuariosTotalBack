using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class EmployeeDto
    {
        public int nid_person { get; set; }
        public int nid_employee { get; set; }
        public string scodperson { get; set; }
        public string sidentification { get; set; }
        public string scodemployee { get; set; }
        public string sfullname { get; set; }
        public string snames { get; set; }
        public string ssurnames { get; set; }
        public string semail { get; set; }
        public int? nid_position { get; set; }
        public string? snamecharge { get; set; }
        public int? nid_company { get; set; }
        public string? scompany { get; set; }
        public string? plaza { get; set; }
        public int? nid_costcenter { get; set; }
        public string scostcenter { get; set; }
        public int? nid_payroll { get; set; }
        public string scodpayroll { get; set; }
        public int? nid_state { get; set; }
        public string sstate { get; set; }
        public string dbirthdate { get; set; }
        public string snamearea { get; set; }
        public string saddress { get; set; }
        public string phone { get; set; }
        public string subigeo { get; set; }
        public string simg { get; set; }
    }

    public class GetFilterEmploye
    {
        public int nid_company { get; set; }
        public int nid_position { get; set; }
        public string sidentification { get; set; }
        public string sfullname { get; set; }
        public int nid_state { get; set; }
        public int currentPage { get; set; }
        public int itemsPerPage { get; set; }
        public int totalItems { get; set; }
        public int totalPages { get; set; }
        public int totalRows { get; set; }
    }
}
