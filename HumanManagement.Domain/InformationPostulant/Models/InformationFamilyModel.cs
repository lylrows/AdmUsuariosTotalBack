using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationFamilyModel: BaseModel.BaseModel
    {
        [Column("nidinformationfamily")]
        public int Id { get; set; }
         
        [Column("kinship")]
        public string Kinship { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("sfullname")]
        public string FullName { get; set; }

        [Column("dbirthdate")]
        public DateTime? BirthDate { get; set; }

        [Column("sage")]
        public string Age { get; set; }

        [Column("soccupation")]
        public string Ocupation { get; set; }

        [Column("scompany")]
        public string Company { get; set; }
        [Column("slastname")]
        public string LastName { get; set; }
        [Column("smotherslastname")]
        public string MotherLastName { get; set; }
        [Column("sfamilytype")]
        public string FamilyType { get; set; }
        [Column("sdocumentnumber")]
        public string DocumentNumber { get; set; } 
        
        [Column("stypedocument")]
        public string TypeDocument { get; set; }
        


    }
}
