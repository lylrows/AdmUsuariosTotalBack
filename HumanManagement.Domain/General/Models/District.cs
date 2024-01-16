using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.General.Models
{
    public class District
    {
        [Column("nid_district")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("nid_province")]
        public int IdProvince { get; set; }



        [Column("nid_department")]
        public int nid_department { get; set; }
        [Column("ncod_province")]
        public int ncod_province { get; set; }
        [Column("ncod_district")]
        public int ncod_district { get; set; }


        [Column("dregister")]
        public DateTime DateRegister { get; set; }
        [Column("nuserregister")]
        public int UserRegister { get; set; }
        [Column("dupdate")]
        public DateTime DateUpdate { get; set; }
        [Column("nuserupdate")]
        public int UserUpdate { get; set; }
    }
}
