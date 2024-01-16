using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class PermitType : BaseModel.BaseModel
    {
        [Column("nid_permit_type")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }
        [Column("scod_type_request")]
        public string scod_type_request { get; set; }
        [Column("scodsub_type_request")]
        public string scodsub_type_request { get; set; }
    }
}
