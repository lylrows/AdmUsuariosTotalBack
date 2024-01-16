using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.HMExactus.Models
{
    public class HMExactusFamilyType
    {
        [Column("sfamilytype_code")]
        public string Code { get; set; }
        [Column("sdescription")]
        public string Description { get; set; }

    }
}
