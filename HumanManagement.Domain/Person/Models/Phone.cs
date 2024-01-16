using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Person.Models
{
    public class Phone
    {
        [Column("nid_phone")]
        public int Id { get; set; }

        [Column("nid_person")]
        public int IdPerson { get; set; }

        [Column("phone")]
        public string phone { get; set; }

        [Column("dregister")]
        public DateTime? DateRegister { get; set; }

        [Column("nuserregister")]
        public int? UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? UserUpdate { get; set; }
        public virtual PersonModel Person { get; set; }
    }
}
