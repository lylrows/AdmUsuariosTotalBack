using System;


namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestLoanDto
    {
        public int IdStaffRequest { get; set; }
        public int IdTypeLoan { get; set; }
        public string TypeLoanName { get; set; }
        public string DetailReasonLoan { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountMonthlyFee { get; set; }
        public int NumberFee { get; set; }
        public string PathFileDocument { get; set; } 
        public int? ntypecase { get; set; }
        public int? ncoutaselect { get; set; }
        public string monthPay { get; set; }
        public string yearPay { get; set; }
        public decimal CobroGratificacion { get; set; }
        public decimal CobroUtilidad { get; set; }
        public decimal RateExactus { get; set; }
        public decimal Balance { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public StaffRequestApproverListDto StaffRequestApproverDto { get; set; }
        public string Comment { get; set; }
        public int TerminosYCond { get; set; }
        public DateTime DateLoan { get; set; }

        public bool bGrati { get; set; }
        public decimal nAddGrati { get; set; }
        public bool bUtil { get; set; }
        public decimal nAddUtilidad { get; set; }
        public int GetIdPerson()
        {
            return StaffRequest.StaffRequestEmployee.IdPerson;
        }
    }

    public class RequestDetailtLoanDto
    {
        public int nid_loan_detail { get; set; }
        public int nid_staff_request { get; set; }
        public float ncoutacount { get; set; }
        public float nbalance { get; set; }
        public float ninterest { get; set; }
        public float namortization { get; set; }
        public float nintmoreigv { get; set; }
        public float ncuotatatotal { get; set; }
        public float ncuotafijasinigv { get; set; }
        public float ntasamensual { get; set; }
        public int nmonth { get; set; }
        public int nyear { get; set; }
        public string smonth { get; set; }
        public string sgratificacion { get; set; }
        public string sutilidad { get; set; }
    }
}
