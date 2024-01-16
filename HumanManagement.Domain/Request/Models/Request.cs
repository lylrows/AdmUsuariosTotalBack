using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Request.Models
{
    public class Request
    {
        [Column("nid_request")]
        public int Id { get; set; }


        [Column("nid_category")]
        public int Id_category { get; set; }

        [Column("nstate")]
        public int State { get; set; }
 
    }
}
