using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class TypeAbsence : BaseModel.BaseModel
    {
        [Column("nid_type_absence")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("sdescripction")]
        public string Description { get; set; }


        [Column("scod_type_request")]
        public string scod_type_request { get; set; }
        [Column("scodsub_type_request")]
        public string scodsub_type_request { get; set; }


    }
}
