using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.General.Models
{
    public class Province : BaseModel.BaseModel
    {
        [Column("nid_province")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("nid_department")]
        public int IdDepartment { get; set; }
    }
}
