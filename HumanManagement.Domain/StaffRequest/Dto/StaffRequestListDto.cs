using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestListDto
    {
        public int Id { get; set; }
        public int IdTypeStaffRequest { get; set; }
        public string TypeStaffRequest { get; set; }
        public string FullNameEmployee { get; set; }
        public DateTime DateIssue { get; set; }
        public string Charge { get; set; }
        public string Area { get; set; }
        public string Company { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public bool Evaluate { get; set; }
        public bool Deleted { get; set; }
        public string scomment { get; set; }

    }
    
    public class GetRequestAdvance
    {
        public string sreason { get; set; }
        public DateTime dregister { get; set; }
       public int nid_advancement { get; set; }

       public int nid_request { get; set; }

        public int nid_collaborator { get; set; }
        public decimal namount { get; set; }

        public int nreason { get; set; }
        public string sdetailreason { get; set; }

        public int nstate { get; set; }

        public string scodemployee { get; set; }
        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }
        public int nid_area { get; set; }

        public string snamearea { get; set; }
        public DateTime dadmissiondate { get; set; }

        public string sidentification { get; set; }
        public string scellphone { get; set; }
        public string snamereason { get; set; }
        public string stateevaluation { get; set; }
        public DateTime dateevaluation { get; set; }
        public string spathsignature { get; set; }
        public string scomment { get; set; }
    }

    public class StaffRequestValidateDaysDto
    {
        public int nid_advancement { get; set; }
        public int ntotal_dias { get; set; }
        public int nid_collaborator { get; set; }
        public bool bexistsregister { get; set; }
    }
}
