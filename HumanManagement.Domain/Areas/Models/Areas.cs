using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Areas.Models
{
    public class Areas
    {
        [Column("nid_area")]
        public int Id { get; set; }

        [Column("nidupperarea")]
        public int IdUpperArea { get; set; }

        [Column("nid_company")]
        public int IdEmpresa { get; set; }

        [Column("snamearea")]
        public string NameArea { get; set; }

        [Column("sboss")]
        public string Boss { get; set; }
        
        [Column("bactive")]
        public bool Active { get; set; }

        [Column("nstate")]
        public int State { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int IdUserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? IdUserUpdate { get; set; }

        [Column("scodexactus")]
        public string CodExactus { get; set; }
    }
}
