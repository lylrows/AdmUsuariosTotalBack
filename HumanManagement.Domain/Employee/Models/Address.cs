using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Employee.Models
{
    public class Address
    {
        [Column("nid_address")]
        public int Id { get; set; }

        [Column("scodlocation")]
        public string CodeLocation { get; set; }

        [Column("saddress")]
        public string AddressDescription { get; set; }

        [Column("nid_district")]
        public int IdDistrict { get; set; }

        [Column("dregister")]
        public DateTime? DateRegister { get; set; }

        [Column("nuserregister")]
        public int? UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? UserUpdate { get; set; }

        [Column("nid_person")]
        public int IdPerson { get; set; }

        [Column("bdefault")]
        public bool? Default { get; set; }
        
    }
}
