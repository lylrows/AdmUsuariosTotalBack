using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Country.Models
{
    public class Country: BaseModel.BaseModel
    {
        [Column("nidcountry")]
        public int Id { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }
    }
}
