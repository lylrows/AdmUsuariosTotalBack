using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Empresa.Models
{
    public class Empresa
    {
        [Column("nid_company")]
        public int Id { get; set; }

        [Column("sdescription")]
        public string Descripcion { get; set; }
        [Column("sbusinessname")]
        public string BusinessName { get; set; }
        [Column("sschema")]
        public string Schema { get; set; }
        [Column("simageurl")]
        public string ImageUrl { get; set; }
        [Column("simagelargeurl")]
        public string ImageUrlLarge { get; set; }


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

        [Column("sruc")]
        public string Ruc { get; set; }


        [Column("nidserverus")]
        public int? IdServerUs { get; set; }

        
    }
}
