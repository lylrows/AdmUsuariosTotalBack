using HumanManagement.Domain.Security.Contracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Home.Models
{
    public class Slider
    {
        [Column("nid_slider")]
        public int Id { get; set; }
        [Column("nid_type")]
        public int IdType { get; set; }

        [NotMapped]
        public string NameType { get; set; }

        [Column("sfilename")]
        public string Filename { get; set; }

        [Column("sfilenamefolder")]
        public string Filenamefolder { get; set; }

        [Column("norder")]
        public int Order { get; set; }

        [Column("bisimage")]
        public bool IsImage { get; set; }

        [Column("surlimage")]
        public string UrlImage { get; set; }

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
