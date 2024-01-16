using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class ListSonDto
    {
        public int nid_son { get; set; }

        public int nid_employee { get; set; }
        public string sfullname { get; set; }
        public DateTime ddateofbirth { get; set; }
        public string slastname { get; set; }
        public string smotherslastname { get; set; }
        public string sfamilytypedescription { get; set; }
    }

    public class InsertSonDto
    {
        public int nid_employee { get; set; }
        public string sfullname { get; set; }
        public string slastname { get; set; }
        public string smotherslastname { get; set; }
        public DateTime ddateofbirth { get; set; }
        public string sfamilytype { get; set; }

    }

    public class UpdateSonDto
    {
        public int nid_son { get; set; }
        public int nid_employee { get; set; }
        public string sfullname { get; set; }
        public string slastname { get; set; }
        public string smotherslastname { get; set; }
        public DateTime ddateofbirth { get; set; }
    }

    public class InsertJobDto
    {
        public int nid_employee { get; set; }
        public string namejob { get; set; }
        public string timejob { get; set; }
        public string positionjob { get; set; }
        public string sfunction { get; set; }
    }

    public class UpdateJobDto
    {
        public int nid_employee { get; set; }
        public string namejob { get; set; }
        public string timejob { get; set; }
        public string positionjob { get; set; }
        public int nid_employee_job { get; set; }
        public string sfunction { get; set; }
    }

    public class DeleteJobDto
    {
        public int nid_employee_job { get; set; }
    }

    public class ListJobDto
    {
        public int nid_employee_job { get; set; }
        public string namejob { get; set; }
        public string timejob { get; set; }
        public string positionjob { get; set; }
        public string sfunction { get; set; }
        public string state { get; set; }
    }

    public class MasterTableGenericDto
    {
        public int nid_mastertable { get; set; }
        public string sdescription_value { get; set; }
        public string sshort_value { get; set; }
        public bool bbreak_requiredfile { get; set; }

    }
}
