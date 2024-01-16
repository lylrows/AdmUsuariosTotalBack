using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Home.Models
{
    public class Document
    {
        [Column("nid_document")]
        public int Id { get; set; }

        [Column("nid_category")]
        public int IdCategory { get; set; }
        [Column("nid_company")]
        public int IdCompany { get; set; }
        [Column("nid_subcategory")]
        public int? IdSubCategory { get; set; }

        [NotMapped]
        public string NameCompany { get; set; }

        
        [NotMapped]
        public string NameCategory { get; set; }
        [NotMapped]
        public string NameSubCategory { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }

        [Column("sfilename")]
        public string Filename { get; set; }

        [Column("sfilenamefolder")]
        public string Filenamefolder { get; set; }

        [Column("bactive")]
        public bool Active { get; set; }

        [Column("dregister")]
        public DateTime DateRegister { get; set; }

        [Column("nuserregister")]
        public int UserRegister { get; set; }

        [Column("dupdate")]
        public DateTime? DateUpdate { get; set; }

        [Column("nuserupdate")]
        public int? UserUpdate { get; set; }
    }
}
