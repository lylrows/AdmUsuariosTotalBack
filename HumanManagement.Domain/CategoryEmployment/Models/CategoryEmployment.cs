using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.CategoryEmployment.Models
{
    public class CategoryEmployment
    {
        [Column("nid_category")]
        public int Id { get; set; }
        [Column("sshort_desc")]
        public int ShortDescription { get; set; }
        [Column("sdescription")]
        public int Description { get; set; }
        [Column("ndays_expiration")]
        public int DaysExpiration { get; set; }
    }
}
