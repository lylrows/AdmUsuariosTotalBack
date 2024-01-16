using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestAccountChangeCts
    {
        [Column("nid_staff_request")]
        public int IdStaffRequest { get; set; }

        [Column("nid_banking_entity_current")]
        public int IdBankingEntityCurrent { get; set; }

        [Column("saccount_number_cts")]
        public string AccountNumberCts { get; set; }

        [Column("nid_currencyaccountcurrent")]
        public int IdCurrencyAccountCurrent { get; set; }

        [Column("sbanking_entity_change")]
        public string BankingEntityChange { get; set; }

        [Column("nid_currencyaccountchange")]
        public int IdCurrencyAccountChange { get; set; }

        [Column("spathfiledocument")]
        public string PathFileDocument { get; set; }
        [Column("saccount_new_number_cts")]
        public string AccountNewNumberCts { get; set; }
        [Column("saccountcci_new_number_cts")]
        public string AccountCCINewNumberCts { get; set; }

        
        [Column("sdestincurrency_cts")]
        public string DestinCurrencyCts { get; set; }
        [Column("sbankingdestin_cts")]
        public string BankingDestinCts { get; set; }
        public void SetIdStaffRequest(int id)
        {
            IdStaffRequest = id;
        }

    }
}
