using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Security.Models
{
    public class ApiAccess : BaseModel.BaseModel
    {
        [Column("nid_api_access")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }
    }
}
