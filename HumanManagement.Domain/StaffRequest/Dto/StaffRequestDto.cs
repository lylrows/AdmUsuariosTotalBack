using HumanManagement.Domain.StaffRequest.Enum;
using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestDto
    {
        public int Id { get; set; }
        public int IdTypeStaffRequest { get; set; }
        public DateTime DateIssue { get; set; }
        public string RegistryNumber { get; set; }
        public string TypeStaffRequest { get; set; }
        public int State { get; set; }
        public string StateEvaluation { get; set; }
        public bool IsAceeptOrRejected { get; set; }
        public DateTime? DateEvaluation { get; set; }
        public string DateEvaluationString { get; set; }
        public StaffRequestEmployeeDto StaffRequestEmployee { get; set; }
        public bool hasAccessToApprover { get; set; }
        public string monthPay { get; set; }
        public string yearPay { get; set; }
        public int TerminosYCond { get; set; }
        public string Comment { get; set; }
        public int serviciofunerarioporc { get; set; }
        public StaffRequestDto()
        {
            DateIssue = DateTime.Now;
            hasAccessToApprover = false;
        }
        public void SetStateName()
        {
            switch ((StaffRequestState)State)
            {
                case StaffRequestState.PENDING:
                    StateEvaluation = "Pendiente";
                    break;
                case StaffRequestState.IN_PROCESS:
                    StateEvaluation = "En Proceso";
                    break;
                case StaffRequestState.APPROVED:
                    StateEvaluation = "Aprobado";
                    break;
                case StaffRequestState.REJECTED:
                    StateEvaluation = "Rechazado";
                    break;
            }
        }
        public void SetIsAceeptOrRejected()
        {
            switch ((StaffRequestState)State)
            {
                case StaffRequestState.PENDING:
                case StaffRequestState.IN_PROCESS:
                    IsAceeptOrRejected = false;
                    break;
                case StaffRequestState.APPROVED:
                case StaffRequestState.REJECTED:
                    IsAceeptOrRejected = true;
                    break;
            }
        }
        public void SetDateEvaluation()
        {
            if (DateEvaluation.HasValue)
            {
                DateEvaluationString = DateEvaluation.Value.ToString("dd/MM/yyyy");
            }
        }

    }

    public class ListIdPersonByChargerDto
    {
        public int nid_person { get; set; }
        public string sfullname { get; set; }
        public int nid_area { get; set; }  
    }
    public class DetailRequestAdvacement
    {
        public int nid_approver { get; set; }

        public int nid_staff_request { get; set; }

        public int nid_charge { get; set; }

        public int nid_employee { get; set; }

        public int nlevel { get; set; }

        public int nstate { get; set; }
    }

    public class ListDatesByEmployeeDto
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public string type_category { get; set; }
    }
}
