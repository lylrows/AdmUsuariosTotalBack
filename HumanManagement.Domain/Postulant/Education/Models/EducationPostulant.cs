using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.Education.Models
{
    public class EducationPostulant : BaseModel.BaseModel
    {
        [Column("nid_education")]
        public int Id { get; set; }

        [Column("nid_person")]
        public int IdPerson { get; set; }

        [Column("scarreer")]
        public string Carreer { get; set; }

        [Column("nidcountry")]
        public int? IdCountry { get; set; }

        [Column("nidtypesstudy")]
        public int IdTypeStudy { get; set; }

        [Column("nidareastudy")]
        public int IdAreaStudy { get; set; }

        [Column("nidinstitution")]
        public int? IdInstitution { get; set; }

        [Column("sotherInstitution")]
        public string OtherInstitution  { get; set; }

        [Column("nidstate")]
        public int IdState { get; set; }

        [Column("smonthstart")]
        public string MonthStart { get; set; }

        [Column("syearstart")]
        public string YearStart { get; set; }

        [Column("smonthend")]
        public string MonthEnd { get; set; }

        [Column("syearend")]
        public string YearEnd { get; set; }

        [Column("bpresent")]
        public bool? Present { get; set; }

    }
}
