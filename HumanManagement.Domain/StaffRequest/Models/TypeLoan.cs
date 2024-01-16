using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class TypeLoan : BaseModel.BaseModel
    {
        [Column("nid_type_loan")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }
    }
}
