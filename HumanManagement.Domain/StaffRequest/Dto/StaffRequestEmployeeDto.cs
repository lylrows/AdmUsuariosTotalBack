using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestEmployeeDto
    {
        public int IdEmployee { get; set; }
        public int IdPerson { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string FullNameComplete { get; set; }
        public string Code { get; set; }
        public string Charge { get; set; }
        public string Area { get; set; }
        public string Company { get; set; }
        public string CellPhone { get; set; }
        public int IdCharge { get; set; }
        public int IdArea { get; set; }
        public DateTime DateAdmissionEmployee { get; set; }
        public string DateAdmission { get; set; }
        public DateTime DateBirth { get; set; }
        public string Dni { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PathSignature { get; set; }
        public string RUC { get; set; }
        public int? SedeId { get; set; }
        public string Sede { get; set; }
        public string CodeBank { get; set; }
        public string AccountBank { get; set; }
        public string Cciaccount_bank { get; set; }
        public string CurrencyAccountBank { get; set; }


        public string CodeBankCts { get; set; }
        public string AccountCts { get; set; }
        public string CurrencyCts { get; set; }
        public string AfpCode { get; set; }

        public void SetDateAdmissionToString()
        {
            DateAdmission = DateAdmissionEmployee.ToString("dd/MM/yyyy");
        }

        public void SetDateAdmissionToDate()
        {
            DateAdmissionEmployee = Convert.ToDateTime(DateAdmission);
        }
    }
}
