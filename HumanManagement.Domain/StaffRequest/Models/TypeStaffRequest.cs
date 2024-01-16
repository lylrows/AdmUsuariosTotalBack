using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class TypeStaffRequest : BaseModel.BaseModel
    {
        [Column("nid_type_staff_request")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("nid_category")]
        public int CategoryId { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }

        [Column("surl")]
        public string Url  { get; set; }
    }
}
