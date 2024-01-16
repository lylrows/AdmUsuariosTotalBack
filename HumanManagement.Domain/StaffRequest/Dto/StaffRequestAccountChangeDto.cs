
namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestAccountChangeDto
    {
        public int IdStaffRequest { get; set; }
        public int IdBankingEntityCurrent { get; set; }
        public string BankingEntityCurrent { get; set; }
        public string AccountNumberCts { get; set; }
        public int IdCurrencyAccountCurrent { get; set; }
        public string BankingEntityChange { get; set; }
        public int IdCurrencyAccountChange { get; set; }
        public string CurrencyAccountCurrent { get; set; }
        public string CurrencyAccountChange { get; set; }
        public string PathFileDocument { get; set; } 
        public StaffRequestDto StaffRequest { get; set; }
        public string AccountCCINewNumberCts { get; set; }
        public string AccountNewNumberCts { get; set; }

        public string OrigenCurrencyCts { get; set; }
        public string BankingOrigenCts { get; set; }
        public string DestinCurrencyCts { get; set; }
        public string BankingDestinCts { get; set; }

        public int GetIdPerson()
        {
            return StaffRequest.StaffRequestEmployee.IdPerson;
        }
    }
}
