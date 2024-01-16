using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Cargo.Models
{
    public class Cargo
    {
        [Column("nid_charge")]
        public int Id { get; set; }

        [Column("nid_area")]
        public int IdArea { get; set; }

        [Column("nid_company")]
        public int IdEmpresa { get; set; }

        [Column("snamecharge")]
        public string NameCargo { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }

        [Column("nstate")]
        public int? State { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int IdUserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? IdUserUpdate { get; set; }

        [Column("scodcharge")]
        public string CodecCharge { get; set; }

        [Column("niduppercharge")]
        public int? IdUpperCargo { get; set; }

        [Column("scodexactus")]
        public string CodExactus { get; set; }
    }
}
