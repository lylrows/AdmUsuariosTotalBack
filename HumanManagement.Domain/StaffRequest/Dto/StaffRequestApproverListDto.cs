using HumanManagement.Domain.StaffRequest.Enum;
using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestApproverListDto
    {
        public int IdEmployee { get; set; }
        public int IdProfile { get; set; }
        public string Charge { get; set; }
        public string Area { get; set; }
        public string Company { get; set; }
        public int Level { get; set; }
        public int State { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewDateString { get; set; }
        public string StateName { get; set; }
        public string FullName { get; set; }
        public string FullNameComplete { get; set; }

        public void ConvertReviewDateToString()
        {
            ReviewDateString = ReviewDate.ToString("dd/MM/yyyy");
        }
        public void SetStateName()
        {
            switch ((StaffRequestState)State)
            {
                case StaffRequestState.PENDING:
                    StateName = "Pendiente";
                    break;
                case StaffRequestState.IN_PROCESS:
                    StateName = "En Proceso";
                    break;
                case StaffRequestState.APPROVED:
                    StateName = "Aprobado";
                    break;
                case StaffRequestState.REJECTED:
                    StateName = "Rechazado";
                    break;
            }
        }
    }
}
