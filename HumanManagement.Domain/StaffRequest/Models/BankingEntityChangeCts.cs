using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class BankingEntityChangeCts : BaseModel.BaseModel
    {
        [Column("nid_banking_entity")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }
    }
}
